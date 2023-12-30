using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 子频道事件数据
	/// </summary>
	public class ChannelEventData
	{
		/// <summary>
		/// 频道ID
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildID { get; set; }

		/// <summary>
		/// 子频道ID
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }

		/// <summary>
		/// 子频道名
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 操作人ID
		/// </summary>
		[JsonProperty("op_user_id")]
		public string OperatorUserID { get; set; }

		/// <summary>
		/// 创建人ID
		/// </summary>
		[JsonProperty("owner_id")]
		public string OwnerID { get; set; }

		/// <summary>
		/// 子频道类型
		/// </summary>
		[JsonProperty("type")]
		public ChannelType Type { get; set; }

		/// <summary>
		/// 子频道子类型
		/// </summary>
		[JsonProperty("sub_type")]
		public ChannelSubType SubType { get; set; }
	}
}
