using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QQBot4Sharp.Exceptions;
using QQBot4Sharp.Internal.API;
using QQBot4Sharp.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QQBot4Sharp.Internal
{
    /// <summary>
    /// 机器人上下文，用于处理Http请求与响应（短连接）
    /// </summary>
    internal class BotContext : IDisposable
	{
		private readonly BotService _service;

		public BotService Service => _service;

		private readonly HttpClient _httpClient;

		private readonly AccessTokenUpdater _accessTokenUpdater;

		public AccessTokenUpdater AccessTokenUpdater => _accessTokenUpdater;

		private readonly BotWebSocket _botWebSocket;

		public BotWebSocket BotWebSocket => _botWebSocket;

		public BotContext(BotService service)
		{
			_service = service;
			_httpClient = new();
			_httpClient.DefaultRequestHeaders.Add("X-Union-Appid", _service.CreateInfo.AppID);
			_httpClient.DefaultRequestHeaders.UserAgent.Add(new($"QQBot4Sharp", Assembly.GetExecutingAssembly().GetName().Version.ToString()));
			_accessTokenUpdater = new(this);
			_botWebSocket = new(this);
		}

		#region HTTP

		public async Task<Response<TRes>> GetAsync<TRes>(string url)
		{
			Log.Debug($"GET {url}");
			_httpClient.DefaultRequestHeaders.Authorization = new("QQBot", await _accessTokenUpdater.GetAccessTokenAsync());
			var response = await _httpClient.GetAsync(url);
			//response.EnsureSuccessStatusCode();
			var str = await response.Content.ReadAsStringAsync();
			Log.Debug($"HTTP响应 => {str}");
			var jobj = JObject.Parse(str);
			var res = new Response<TRes>();
			if (jobj.ContainsKey("code")) // 尼玛API就不能统一用code、message、data格式吗？？？
			{
				res.Code = jobj["code"].Value<int>();
				res.Message = jobj["message"].Value<string>();
				res.Data = default;
			}
			else
			{
				res.Code = 0;
				res.Message = "ok";
				res.Data = JsonConvert.DeserializeObject<TRes>(str);
			}
			if (!res.IsSuccess)
			{
				throw new APIException(res.Code, res.Message);
			}
			return res;
		}

		public async Task<Response<TRes>> PostAsync<TReq, TRes>(string url, TReq req, bool noAuth = false)
		{
			Log.Debug($"POST {url}");
			if (!noAuth)
			{
				_httpClient.DefaultRequestHeaders.Authorization = new("QQBot", await _accessTokenUpdater.GetAccessTokenAsync());
			}
			var json = JsonConvert.SerializeObject(req, Formatting.None);
			Log.Debug($"HTTP请求 <= {json}");
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync(url, content);
			//response.EnsureSuccessStatusCode();
			var str = await response.Content.ReadAsStringAsync();
			Log.Debug($"HTTP响应 => {str}");
			var jobj = JObject.Parse(str);
			var res = new Response<TRes>();
			if (jobj.ContainsKey("code")) // 尼玛API就不能统一用code、message、data格式吗？？？
			{
				res.Code = jobj["code"].Value<int>();
				res.Message = jobj["message"].Value<string>();
				res.Data = default;
			}
			else
			{
				res.Code = 0;
				res.Message = "ok";
				res.Data = JsonConvert.DeserializeObject<TRes>(str);
			}
			if (!res.IsSuccess)
			{
				throw new APIException(res.Code, res.Message);
			}
			return res;
		}

		public async Task DeleteAsync(string url)
		{
			Log.Debug($"DELETE {url}");
			var response = await _httpClient.DeleteAsync(url);
			var str = await response.Content.ReadAsStringAsync();
			if (!string.IsNullOrEmpty(str))
			{
				var res = new Response();
				var jobj = JObject.Parse(str);
				if (jobj.ContainsKey("code")) // 尼玛API就不能统一用code、message、data格式吗？？？
				{
					res.Code = jobj["code"].Value<int>();
					res.Message = jobj["message"].Value<string>();
				}
				else
				{
					res.Code = 0;
					res.Message = "ok";
				}
				if (!res.IsSuccess)
				{
					throw new APIException(res.Code, res.Message);
				}
			}
			else
			{
				response.EnsureSuccessStatusCode();
			}
		}

		private static readonly StringContent _emptyStringContent = new(string.Empty);

		public async Task PutAsync(string url)
		{
			Log.Debug($"PUT {url}");
			var response = await _httpClient.PutAsync(url, _emptyStringContent);
			var str = await response.Content.ReadAsStringAsync();
			if (!string.IsNullOrEmpty(str))
			{
				var res = new Response();
				var jobj = JObject.Parse(str);
				if (jobj.ContainsKey("code")) // 尼玛API就不能统一用code、message、data格式吗？？？
				{
					res.Code = jobj["code"].Value<int>();
					res.Message = jobj["message"].Value<string>();
				}
				else
				{
					res.Code = 0;
					res.Message = "ok";
				}
				if (!res.IsSuccess)
				{
					throw new APIException(res.Code, res.Message);
				}
			}
			else
			{
				response.EnsureSuccessStatusCode();
			}
		}

		#endregion

		#region 通用

		private bool _isRunning = false;

		public async Task StartAsync()
		{
			if (_isRunning)
			{
				throw new Exception("重复启动机器人服务");
			}
			await _botWebSocket.StartAsync();
			_isRunning = true;
		}

		public async Task StopAsync()
		{
			if (!_isRunning)
			{
				return;
			}
			await _botWebSocket.StopAsync();
			_isRunning = false;
		}

		#endregion

		#region API

		public async Task<GuildMessage> SendChannelMessageAsync(GuildMessageReq message, string channalID)
			=> await PostAsync<GuildMessageReq, GuildMessage>($"https://api.sgroup.qq.com/channels/{channalID}/messages", message);

		public async Task<GuildMessage> SendDirectMessageAsync(GuildMessageReq message, string guildID)
			=> await PostAsync<GuildMessageReq, GuildMessage>($"https://api.sgroup.qq.com/dms/{guildID}/messages", message);

		public async Task<DirectMessageSession> CreateDirectMessageSessionAsync(DirectMessageSessionCreateInfo info)
			=> await PostAsync<DirectMessageSessionCreateInfo, DirectMessageSession>($"https://api.sgroup.qq.com/users/@me/dms", info);

		public async Task DeleteChannelMessageAsync(string channelID, string messageID, bool hideTip = false)
			=> await DeleteAsync($"https://api.sgroup.qq.com/channels/{channelID}/messages/{messageID}?hidetip={hideTip}");

		public async Task DeleteDirectMessageAsync(string guildID, string messageID, bool hideTip = false)
			=> await DeleteAsync($"https://api.sgroup.qq.com/dms/{guildID}/messages/{messageID}?hidetip={hideTip}");

		public async Task<QQMessageRes> SendUserMessageAsync(QQMessageReq message, string openID)
			=> await PostAsync<QQMessageReq, QQMessageRes>($"https://api.sgroup.qq.com/v2/users/{openID}/messages", message);

		public async Task<QQMessageRes> SendGroupMessageAsync(QQMessageReq message, string groupOpenID)
			=> await PostAsync<QQMessageReq, QQMessageRes>($"https://api.sgroup.qq.com/v2/groups/{groupOpenID}/messages", message);

		public async Task<MediaRes> UploadUserMediaAsync(MediaReq media, string openID)
			=> await PostAsync<MediaReq, MediaRes>($"https://api.sgroup.qq.com/v2/users/{openID}/files", media);

		public async Task<MediaRes> UploadGroupMediaAsync(MediaReq media, string groupOpenID)
			=> await PostAsync<MediaReq, MediaRes>($"https://api.sgroup.qq.com/v2/groups/{groupOpenID}/files", media);

		public async Task SetEmojiReactionAsync(string channelID, string messageID, EmojiType type, string emojiID)
			=> await PutAsync($"https://api.sgroup.qq.com/channels/{channelID}/messages/{messageID}/reactions/{(uint)type}/{emojiID}");

		public async Task DeleteEmojiReactionAsync(string channelID, string messageID, EmojiType type, string emojiID)
			=> await DeleteAsync($"https://api.sgroup.qq.com/channels/{channelID}/messages/{messageID}/reactions/{(uint)type}/{emojiID}");

		private async Task<ReactionRes> GetEmojiReactionAsync(string channelID, string messageID, EmojiType type, string emojiID, string cookie, int? limit)
			=> await GetAsync<ReactionRes>($"https://api.sgroup.qq.com/channels/{channelID}/messages/{messageID}/reactions/{(uint)type}/{emojiID}?cookie={cookie}&limit={limit}");

		public async Task RespondToInteractionAsync(string interactionID)
			=> await PutAsync($"https://api.sgroup.qq.com/interactions/{interactionID}");

		public async Task<List<GuildUser>> GetEmojiReactionAsync(string channelID, string messageID, EmojiType type, string emojiID)
		{
			var result = new List<GuildUser>();
			ReactionRes res;
			string cookie = null;
			int? limit = 50;
			do
			{
				res = await GetEmojiReactionAsync(channelID, messageID, type, emojiID, cookie, limit);
				result.AddRange(res.Users);
				cookie = res.Cookie;
				limit = null;
			} while (!res.IsEnd);

			return result;
		}

		#endregion

		public void Dispose()
		{
			if (_isRunning)
			{
				StopAsync().Wait();
			}

			_botWebSocket.Dispose();
			_httpClient.Dispose();
		}
	}
}
