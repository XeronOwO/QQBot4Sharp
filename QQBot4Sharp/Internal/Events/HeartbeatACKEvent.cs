using QQBot4Sharp.Internal.API;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QQBot4Sharp.Internal.Events
{
	internal class HeartbeatACKEvent : Event
	{
		public HeartbeatACKEvent()
		{

		}

		public override async Task HandleAsync(Payload payload)
		{
			if (payload.OpCode != OpCode.HeartbeatACK)
			{
				return;
			}

			Log.Information("心跳完成");

			await Task.CompletedTask;
		}
	}
}
