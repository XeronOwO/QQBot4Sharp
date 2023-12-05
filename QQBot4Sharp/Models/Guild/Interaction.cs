using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// 交互
	/// </summary>
	public class Interaction
	{
		/// <summary>
		/// 平台方事件 ID，可以用于被动消息发送
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }

		/// <summary>
		/// 事件类型<br/>
		/// 按钮事件固定是 11
		/// </summary>
		[JsonProperty("type")]
		public int Type { get; set; }

		/// <summary>
		/// 聊天类型<br/>目前只有群和单聊有该字段，1 群聊，2 单聊，后续加入 3 频道
		/// </summary>
		[JsonProperty("chat_type")]
		public int ChatType { get; set; }

		/// <summary>
		/// 消息生产时间
		/// </summary>
		[JsonProperty("timestamp")]
		public string Timestamp { get; set; }

		/// <summary>
		/// 频道的OpenID
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildID { get; set; }

		/// <summary>
		/// 文字子频道的OpenID
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelID { get; set; }

		/// <summary>
		/// 群聊的OpenID
		/// </summary>
		[JsonProperty("group_open_id")]
		public string GroupOpenID { get; set; }

		/// <summary>
		/// 操作按钮的data字段值【在发送按钮时规划】
		/// </summary>
		[JsonProperty("data.resoloved.button_data")]
		public string ButtonData { get; set; }

		/// <summary>
		/// 操作按钮的id字段值【在发送按钮时规划】
		/// </summary>
		[JsonProperty("data.resoloved.button_id")]
		public string ButtonID { get; set; }

		/// <summary>
		/// 操作的用户OpenID
		/// </summary>
		[JsonProperty("data.resoloved.user_id")]
		public string UserID { get; set; }

		/// <summary>
		/// 操作的消息ID
		/// </summary>
		[JsonProperty("data.resoloved.message_id")]
		public string MessageID { get; set; }

		/// <summary>
		/// 默认 1
		/// </summary>
		[JsonProperty("version")]
		public int Version { get; set; }

		/// <summary>
		/// 机器人的AppID
		/// </summary>
		[JsonProperty("application_id")]
		public string ApplicationID { get; set; }
	}
}
