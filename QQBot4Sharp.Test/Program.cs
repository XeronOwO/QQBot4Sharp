using Newtonsoft.Json.Linq;
using QQBot4Sharp.Models;
using Serilog;
using System.Text;
using System.Text.RegularExpressions;

namespace QQBot4Sharp.Test
{
    internal class Program
	{
		private static JObject _jConfig = [];

		static async Task Main(string[] args)
		{
			// 配置日志器
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.Console()
				.CreateLogger();

			// 读取配置文件
			_jConfig = JObject.Parse(File.ReadAllText("config.json"));
			var info = new BotCreateInfo()
			{
				AppID = (string?)_jConfig["AppID"],
				ClientSecret = (string?)_jConfig["ClientSecret"],
				Intents = Intents.ALL,
			};

			// 创建机器人服务
			using var bot = new BotService(info);

			// 注册事件
			bot.OnReadyAsync += OnReadyAsync;
			bot.OnAtMessageCreateAsync += OnAtMessageCreateAsync;
			bot.OnDirectMessageCreateAsync += OnDirectMessageCreateAsync;
			bot.OnMessageCreateAsync += OnMessageCreateAsync;
			bot.OnC2CMessageCreateAsync += OnC2CMessageCreateAsync;
			bot.OnGroupAtMessageCreateAsync += OnGroupAtMessageCreateAsync;
			bot.OnMessageReactionAddAsync += OnMessageReactionAddAsync;
			bot.OnMessageReactionRemoveAsync += OnMessageReactionRemoveAsync;
			bot.OnInteractionCreateAsync += OnInteractionCreateAsync;

			// 启动和停止
			await bot.StartAsync();
			Console.ReadLine();
			await bot.StopAsync();
		}

		#region 通用事件

		/// <summary>
		/// READY 事件
		/// </summary>
		private static async Task OnReadyAsync(object sender, ContextEventArgs e)
		{
			Log.Information("Ready");

			var user = await e.Service.GetCurrentUser();
			Log.Information($"当前用户：[{user.ID}]{user.Username}");

			await Task.CompletedTask;
		}

		#endregion

		#region 频道测试

		private static readonly Regex _atTestRegex = new("<@![0-9]+> 测试");
		private static readonly Regex _atPrivateTestRegex = new("<@![0-9]+> 私信测试");
		private static readonly Regex _atDeleteTestRegex = new("<@![0-9]+> 撤回测试");
		private static readonly Regex _atEmojiTestRegex = new("<@![0-9]+> 表情测试");
		private static readonly Regex _atMarkDownTestRegex = new("<@![0-9]+> MarkDown测试");

		/// <summary>
		/// 文字子频道At消息事件
		/// </summary>
		private static async Task OnAtMessageCreateAsync(object sender, AtMessageEventArgs e)
		{
			// 收到 “@Bot 测试” 消息后，回复 “At测试”
			if (_atTestRegex.IsMatch(e.Message.Content))
			{
				await e.ReplyAsync(new()
				{
					Content = "At测试",
					MessageID = e.Message.ID,
				});
			}

			// 收到 “@Bot 私信测试” 消息后，私信回复 “文字频道的私信测试”
			if (_atPrivateTestRegex.IsMatch(e.Message.Content))
			{
				var dms = await e.CreateDirectMessageSessionAsync(new()
				{
					RecipientID = e.Message.Author.ID,
					SourceGuildID = e.Message.GuildID,
				});
				await e.SendDirectMessageAsync(new()
				{
					Content = "文字频道的私信测试",
					MessageID = e.Message.ID,
				}, dms.GuildID);
			}

			// 收到 “@Bot 撤回测试” 消息后，先发送一个消息，过几秒后撤回
			if (_atDeleteTestRegex.IsMatch(e.Message.Content))
			{
				var delay = 5 * 1000;
				var msg = await e.ReplyAsync(new()
				{
					Content = $"该消息将在{delay / 1000}秒后撤回",
					MessageID = e.Message.ID,
				});
				await Task.Delay(delay);
				await e.DeleteChannelMessageAsync(msg);
			}

			// 收到 “@Bot 表情测试” 消息后，先发送一个消息，进行表情测试
			if (_atEmojiTestRegex.IsMatch(e.Message.Content))
			{
				var delay = 3 * 1000;
				var msg = await e.ReplyAsync(new()
				{
					Content = "表情测试",
					MessageID = e.Message.ID,
				});
				await Task.Delay(delay);
				var emoji = new Emoji()
				{
					ID = "128076",
					Type = EmojiType.Emoji,
				};
				await e.SetEmojiReactionAsync(msg, emoji);
				await Task.Delay(delay);
				var users = await e.GetEmojiReactionAsync(msg, emoji);
				var sb = new StringBuilder();
				sb.Append("表情表态列表：");
				foreach (var user in users)
				{
					sb.Append(user.Username);
					sb.Append(' ');
				}
				await e.ReplyAsync(new()
				{
					Content = sb.ToString(),
					MessageID = e.Message.ID,
				});
				await Task.Delay(delay);
				await e.DeleteEmojiReactionAsync(msg, emoji);
			}

			// 收到 “@Bot MarkDown测试” 消息后，进行MarkDown测试
			if (_atMarkDownTestRegex.IsMatch(e.Message.Content))
			{
				var builder = new MarkDownBuilder();
				builder.At(e.Message.Author.ID);
				builder.Text(" MarkDown测试\n");
				builder.Command("/MarkDown测试");
				await e.ReplyAsync(new()
				{
					Markdown = builder.Build(),
				});
			}
		}

		/// <summary>
		/// 频道私信事件
		/// </summary>
		private static async Task OnDirectMessageCreateAsync(object sender, DirectMessageEventArgs e)
		{
			// 收到 “测试” 消息后，回复 “私信测试”
			if (e.Message.Content == "测试")
			{
				await e.ReplyAsync(new()
				{
					Content = "私信测试",
					MessageID = e.Message.ID,
				});
			}

			// 收到 “撤回测试” 消息后，先发送一个消息，过几秒后撤回
			if (e.Message.Content == "撤回测试")
			{
				var delay = 5 * 1000;
				var msg = await e.ReplyAsync(new()
				{
					Content = $"该消息将在{delay / 1000}秒后撤回",
					MessageID = e.Message.ID,
				});
				await Task.Delay(delay);
				await e.DeleteDirectMessageAsync(msg);
			}
		}

		/// <summary>
		/// 文字子频道全量消息事件（仅私域）
		/// </summary>
		private static async Task OnMessageCreateAsync(object sender, GuildMessageEventArgs e)
		{
			// 收到 “测试” 消息后，回复 “文字频道测试”
			if (e.Message.Content == "测试")
			{
				await e.ReplyAsync(new()
				{
					Content = "文字频道测试",
					MessageID = e.Message.ID,
				});
			}
		}

		/// <summary>
		/// 消息表态添加事件
		/// </summary>
		private static async Task OnMessageReactionAddAsync(object sender, MessageReactionEventArgs e)
		{
			Log.Information("MessageReactionAdd");

			await Task.CompletedTask;
		}

		/// <summary>
		/// 消息表态移除事件
		/// </summary>
		private static async Task OnMessageReactionRemoveAsync(object sender, MessageReactionEventArgs e)
		{
			Log.Information("MessageReactionRemove");

			await Task.CompletedTask;
		}

		/// <summary>
		/// 按钮交互
		/// </summary>
		private static async Task OnInteractionCreateAsync(object sender, InteractionEventArgs e)
		{
			Log.Information("InteractionCreate");

			// 由于 websocket 推送事件是单向的，开发者收到事件之后，需要进行一次"回应"，告知QQ后台，事件已经收到，否则客户端会一直处于loading状态，直到超时。
			await e.RespondToInteractionAsync(e.Interaction.ID);
		}

		#endregion

		#region QQ聊天测试

		/// <summary>
		/// 单聊事件
		/// </summary>
		private static async Task OnC2CMessageCreateAsync(object sender, Models.QQ.QQMessageEventArgs e)
		{
			await e.ReplyAsync(new()
			{
				Content = "私聊测试",
				Type = QQMessageType.Text,
				MessageID = e.Message.ID,
			});
		}

		/// <summary>
		/// 群聊事件
		/// </summary>
		private static async Task OnGroupAtMessageCreateAsync(object sender, Models.QQ.QQMessageEventArgs e)
		{
			await e.ReplyAsync(new()
			{
				Content = "群聊测试",
				Type = QQMessageType.Text,
				MessageID = e.Message.ID,
			});
		}

		#endregion
	}
}
