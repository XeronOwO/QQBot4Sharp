using QQBot4Sharp.Internal.API;
using QQBot4Sharp.Models.QQ;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QQBot4Sharp.Internal.Events
{
	internal class C2CMessageCreateEvent : Event
	{
		public override async Task HandleAsync(Payload payload)
		{
			if (payload.OpCode != OpCode.Dispatch)
			{
				return;
			}
			if (payload.Type != "C2C_MESSAGE_CREATE")
			{
				return;
			}

			await BotService.SendC2CMessageCreateEventAsync(new(BotContext, payload.Cast<MessageRecv>().Data));
		}
	}
}
