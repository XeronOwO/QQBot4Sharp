using QQBot4Sharp.Internal.API;
using QQBot4Sharp.Internal.Models;
using Serilog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace QQBot4Sharp.Internal
{
	/// <summary>
	/// AccessToken更新器，可以自动更新AccessToken
	/// </summary>
	internal class AccessTokenUpdater
	{
		private readonly BotContext _context;

		private readonly AccessTokenInfo _info;

		public AccessTokenUpdater(BotContext context)
		{
			_context = context;
			_info = new();
		}

		/// <summary>
		/// 获取AccessToken，如果AccessToken已过期则自动更新
		/// </summary>
		/// <returns>AccessToken</returns>
		public async Task<string> GetAccessTokenAsync()
		{
			if (!_info.IsExpired)
			{
				return _info.AccessToken;
			}

			try
			{
				GetAppAccessTokenRes res = await _context.PostAsync<GetAppAccessTokenReq, GetAppAccessTokenRes>(
					"https://bots.qq.com/app/getAppAccessToken",
					new(_context.Service.CreateInfo.AppID, _context.Service.CreateInfo.ClientSecret),
					true
					);
				_info.FromRes(res);

				Log.Information($"更新AccessToken成功：{_info}");
			}
			catch (Exception e)
			{
				Log.Error(e, "更新AccessToken时出现异常");
			}

			return _info.AccessToken;
		}
	}
}
