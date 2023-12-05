using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Internal.API
{
	internal struct HelloRes
	{
		[JsonProperty("heartbeat_interval")]
		public int HeartbeatInterval;
	}
}
