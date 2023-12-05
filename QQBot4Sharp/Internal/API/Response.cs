using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Internal.API
{
	internal struct Response
	{
		[JsonProperty("code")]
		public int Code;

		[JsonProperty("message")]
		public string Message;

		[JsonIgnore]
		public bool IsSuccess => Code == 0;
	}
}
