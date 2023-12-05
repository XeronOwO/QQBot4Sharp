using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Internal.API
{
	internal struct GetAppAccessTokenRes
	{
		[JsonProperty("access_token")]
		public string AccessToken;

		[JsonProperty("expires_in")]
		public int ExpiresIn;
	}
}
