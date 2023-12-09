using QQBot4Sharp.Internal.API;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QQBot4Sharp.Internal.Events
{
	internal class ResumeEvent : Event
	{
		public override async Task HandleAsync(Payload payload)
		{
			if (payload.OpCode != OpCode.Dispatch)
			{
				return;
			}
			if (payload.Type != "RESUMED")
			{
				return;
			}

			await OnResume(payload);
		}

		private async Task OnResume(Payload payload)
		{
			Log.Information("恢复会话成功");

			EventBus.Get<HeartbeatEvent>().Start();

			await BotService.SendResumeEventAsync(new(BotContext));
		}
	}
}
