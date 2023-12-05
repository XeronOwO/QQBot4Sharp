using Newtonsoft.Json;
using QQBot4Sharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Internal.API
{
	internal struct IdentifyReq
	{
		[JsonProperty("token")]
		public string Token;

		[JsonProperty("intents")]
		public Intents Intents;

		[JsonProperty("shard")]
		public List<int> Shard;

		[JsonProperty("properties")]
		public Dictionary<string, string> Properties;
	}
}
