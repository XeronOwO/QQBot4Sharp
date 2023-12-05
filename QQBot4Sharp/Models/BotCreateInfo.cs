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
		/// 订阅事件
		/// </summary>
		public Intents Intents { get; set; } = Intents.ALL_PUBLIC;

		/// <summary>
		/// 创建Bot服务创建信息
		/// </summary>
		public BotCreateInfo() { }

		/// <summary>
		/// 创建Bot服务创建信息
		/// </summary>
		/// <param name="appID">AppID，从开放平台管理端获得</param>
		/// <param name="clientSecret">ClientSecret，从开放平台管理端获得</param>
		/// <param name="intents">订阅事件</param>
		public BotCreateInfo(string appID, string clientSecret, Intents intents = Intents.ALL_PUBLIC)
		{
			AppID = appID;
			ClientSecret = clientSecret;
			Intents = intents;
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"AppID={AppID}, ClientSecret={ClientSecret}, Intents={Intents}";
		}
	}
}
