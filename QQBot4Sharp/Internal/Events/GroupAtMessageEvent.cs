using QQBot4Sharp.Internal.API;
using QQBot4Sharp.Models.QQ;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QQBot4Sharp.Internal.Events
{
	internal class GroupAtMessageEvent : Event
	{
		public override async Task HandleAsync(Payload payload)
		{
			if (payload.OpCode != OpCode.Dispatch)
			{
				return;
			}
			if (payload.Type != "GROUP_AT_MESSAGE_CREATE")
			{
				return;
			}

			await BotService.SendGroupAtMessageCreateEventAsync(new(BotContext, payload.Cast<MessageRecv>().Data));
		}
	}
}
