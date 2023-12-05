using QQBot4Sharp.Internal.API;
using System;

namespace QQBot4Sharp.Internal.Models
{
	internal class AccessTokenInfo
	{
		private string _accessToken = string.Empty;

		public string AccessToken => _accessToken;

		private DateTime _expireTime;

		/// <summary>
		/// 失效时间<br/>尼玛有的API返回具体时间，有的API返回时间戳数值，而且这数值还是字符串类型的，你后端怎么这么不统一啊？？？
		/// </summary>
		public DateTime ExpireTime => _expireTime;

		public bool IsExpired => DateTime.Now >= _expireTime;

		public void FromRes(GetAppAccessTokenRes res)
		{
			_accessToken = res.AccessToken;
			_expireTime = DateTime.Now.AddSeconds(res.ExpiresIn);
		}

		public override string ToString()
		{
			return $"AccessToken={_accessToken}, ExpireTime={_expireTime:yyyy-MM-dd HH:mm:ss}";
		}
	}
}
