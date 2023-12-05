using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Internal.API
{
	internal struct GetAppAccessTokenReq
	{
		[JsonProperty("appId")]
		public string AppID;

		[JsonProperty("clientSecret")]
		public string ClientSecret;

		public GetAppAccessTokenReq(string appID, string clientSecret)
		{
			AppID = appID;
			ClientSecret = clientSecret;
		}
	}
}
