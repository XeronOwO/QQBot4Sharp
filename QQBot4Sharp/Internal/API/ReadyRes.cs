using Newtonsoft.Json;
using QQBot4Sharp.Models.Guild;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Internal.API
{
	internal struct ReadyRes
	{
		[JsonProperty("version")]
		public int Version;

		[JsonProperty("session_id")]
		public string SessionID;

		[JsonProperty("user")]
		public User User;

		[JsonProperty("shard")]
		public List<int> Shard;
	}
}
