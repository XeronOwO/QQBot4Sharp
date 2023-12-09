using Newtonsoft.Json.Linq;
using QQBot4Sharp.Internal.API;
using QQBot4Sharp.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QQBot4Sharp.Internal.Events
{
	internal class HelloEvent : Event
	{
		public HelloEvent()
		{

		}

		public override async Task HandleAsync(Payload payload)
		{
			if (payload.OpCode != OpCode.Hello)
			{
				return;
			}

			await OnHello(payload.Cast<HelloRes>());
		}

		private int _heartbeatInterval;

		public int HeartbeatInterval => _heartbeatInterval;

		private async Task OnHello(Payload<HelloRes> payload)
		{
			_heartbeatInterval = payload.Data.HeartbeatInterval;

			var accessToken = await BotContext.AccessTokenUpdater.GetAccessTokenAsync();
			var heartbeatEvent = EventBus.Get<HeartbeatEvent>();
			if (string.IsNullOrEmpty(heartbeatEvent.SessionID))
			{
				await ConnectAsync(accessToken);
			}
			else
			{
				await ReconnectAsync(accessToken, heartbeatEvent.SessionID, heartbeatEvent.Seq);
			}
		}

		private async Task ConnectAsync(string accessToken)
		{
			await BotWebSocket.SendMessageAsync<IdentifyReq>(new()
			{
				OpCode = OpCode.Identify,
				Data = new()
				{
					Token = $"QQBot {accessToken}",
					Intents = Intents.ALL,
					Shard = new() { 0, 1 },
					Properties = new(),
				},
			});
		}

		private async Task ReconnectAsync(string accessToken, string sessionID, int? seq)
		{
			await BotWebSocket.SendMessageAsync<ResumeReq>(new()
			{
				OpCode = OpCode.Resume,
				Data = new()
				{
					Token = $"QQBot {accessToken}",
					SessionID = sessionID,
					Seq = seq,
				},
			});
		}
	}
}
