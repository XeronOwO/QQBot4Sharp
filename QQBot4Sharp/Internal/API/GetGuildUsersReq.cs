using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Internal.API
{
	internal class GetGuildUsersReq
	{
		[JsonProperty("before")]
		public string Before { get; set; }

		[JsonProperty("after")]
		public string After { get; set; }

		[JsonProperty("limit")]
		public int? Limit { get; set; }
	}
}
