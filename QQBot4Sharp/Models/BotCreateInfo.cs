using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// Bot服务创建信息
	/// </summary>
	public class BotCreateInfo
	{
		/// <summary>
		/// AppID，从开放平台管理端获得
		/// </summary>
		public string AppID { get; set; }

		/// <summary>
		/// ClientSecret，从开放平台管理端获得
		/// </summary>
		public string ClientSecret { get; set; }

		/// <summary>
		/// 订阅事件，默认订阅所有公开事件
		/// </summary>
		public Intents Intents { get; set; }

		/// <summary>
		/// 重连间隔，默认5秒
		/// </summary>
		public int ReconnectInterval { get; set; }

		/// <summary>
		/// 创建Bot服务创建信息
		/// </summary>
		public BotCreateInfo()
		{
			Intents = Intents.ALL_PUBLIC;
			ReconnectInterval = 5000;
		}

		/// <summary>
		/// 创建Bot服务创建信息
		/// </summary>
		/// <param name="appID">AppID，从开放平台管理端获得</param>
		/// <param name="clientSecret">ClientSecret，从开放平台管理端获得</param>
		/// <param name="intents">订阅事件，默认订阅所有公开事件</param>
		/// <param name="reconnectInterval">重连间隔，默认5秒</param>
		public BotCreateInfo(
			string appID,
			string clientSecret,
			Intents intents = Intents.ALL_PUBLIC,
			int reconnectInterval = 5000)
		{
			AppID = appID;
			ClientSecret = clientSecret;
			Intents = intents;
			ReconnectInterval = reconnectInterval;
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"AppID={AppID}, ClientSecret={ClientSecret}, Intents={Intents}";
		}
	}
}
