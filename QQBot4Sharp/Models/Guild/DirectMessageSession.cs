using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// 私信会话（DMS）
	/// </summary>
	public class DirectMessageSession
	{
		/// <summary>
		/// 私信会话关联的频道ID
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildID { get; set; }

		/// <summary>
		/// 私信会话关联的子频道ID
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelID { get; set; }

		/// <summary>
		/// 创建私信会话时间戳<br/>尼玛有的API返回具体时间，有的API返回时间戳数值，而且这数值还是字符串类型的，你后端怎么这么不统一啊？？？
		/// </summary>
		[JsonProperty("create_time")]
		public string CreateTime { get; set; }
	}
}
