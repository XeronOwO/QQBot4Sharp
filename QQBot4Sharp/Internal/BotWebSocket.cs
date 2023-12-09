using Newtonsoft.Json;
using QQBot4Sharp.Internal.API;
using QQBot4Sharp.Internal.Events;
using Serilog;
using System;
using System.Text;
using System.Threading.Tasks;
using WatsonWebsocket;

namespace QQBot4Sharp.Internal
{
	/// <summary>
	/// 机器人WebSocket，用于处理WebSocket交互（长连接）
	/// </summary>
	internal class BotWebSocket : IDisposable
	{
		private readonly BotContext _botContext;

		public BotContext BotContext => _botContext;

		private readonly EventBus _eventBus;

		public BotWebSocket(BotContext botContext)
		{
			_botContext = botContext;
			_eventBus = new EventBus(this)
				.Append<HelloEvent>()
				.Append<ReadyEvent>()
				.Append<ResumeEvent>()
				.Append<HeartbeatEvent>()
				.Append<HeartbeatACKEvent>()
				.Append<MessageCreateEvent>()
				.Append<AtMessageCreateEvent>()
				.Append<DirectMessageCreateEvent>()
				.Append<C2CMessageCreateEvent>()
				.Append<GroupAtMessageEvent>()
				.Append<MessageReactionAddEevnt>()
				.Append<MessageReactionRemoveEevnt>()
				.Append<InteractionEvent>()
				;
		}

		#region 通用

		private WatsonWsClient _client;

		public async Task StartAsync()
		{
			Log.Information("正在启动机器人WebSocket");

			GatewayRes res = await _botContext.GetAsync<GatewayRes>("https://api.sgroup.qq.com/gateway");
			Log.Information($"正在连接WebSocket：Url={res.Url}");

			_client?.Dispose();
			_client = new(new(res.Url));
			_client.ServerConnected += ServerConnected;
			_client.ServerDisconnected += ServerDisconnected;
			_client.MessageReceived += MessageReceived;
			await _client.StartAsync();
		}

		public async Task StopAsync()
		{
			Log.Information("正在停止机器人WebSocket");

			await _client.StopAsync();
		}

		public async Task SendMessageAsync(Payload req)
		{
			var data = JsonConvert.SerializeObject(req, Formatting.None);
			Log.Debug($"WebSocket发送 <= {data}");
			await _client.SendAsync(Encoding.UTF8.GetBytes(data));
		}

		public async Task SendMessageAsync<T>(Payload<T> req)
		{
			var data = JsonConvert.SerializeObject(req, Formatting.None);
			Log.Debug($"WebSocket发送 <= {data}");
			await _client.SendAsync(Encoding.UTF8.GetBytes(data));
		}

		#endregion

		#region 事件

		private void ServerConnected(object sender, EventArgs e)
		{
			Log.Information($"WebSocket连接成功");
		}

		private Task reconnectTask;

		private void ServerDisconnected(object sender, EventArgs e)
		{
			Log.Information("WebSocket与服务器断开连接");
			_eventBus.Get<HeartbeatEvent>().Stop();

			lock (this)
			{
				reconnectTask ??= ReconnectTask();
			}
		}

		private async Task ReconnectTask()
		{
			var interval = _botContext.Service.CreateInfo.ReconnectInterval;
			Log.Information($"计划在{interval}毫秒后重连");
			await Task.Delay(interval);
			await StartAsync();
			lock (this)
			{
				reconnectTask = null;
			}
		}

		private async void MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			var data = Encoding.UTF8.GetString(e.Data);
			Log.Debug($"WebSocket接收 => {data}");
			var payload = JsonConvert.DeserializeObject<Payload>(data);

			await _eventBus.DispatchAsync(payload);
		}

		#endregion

		public void Dispose()
		{
			_eventBus.Dispose();
			_client.Dispose();
		}
	}
}
