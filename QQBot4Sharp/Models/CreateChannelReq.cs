using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 子频道创建信息
	/// </summary>
	public class CreateChannelReq
	{
		/// <summary>
		/// 子频道名
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

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

		/// <summary>
		/// 排序值<br/>
		/// - postiton 从 1 开始<br/>
		/// - 当子频道类型为 子频道分组（ChannelType=4）时，由于 position 1 被未分组占用，所以 position 只能从 2 开始<br/>
		/// - 如果不传默认追加到分组下最后一个<br/>
		/// - 如果填写一个已经存在的值，那么会插入在原来的元素之前<br/>
		/// - 如果填写一个较大值，与不填是相同的表现，同时存储的值会根据真实的 position 进行重新计算，并不会直接使用传入的值<br/>
		/// </summary>
		[JsonProperty("position")]
		public int Position { get; set; }

		/// <summary>
		/// 所属分组 ID，仅对子频道有效，对 子频道分组（ChannelType=4） 无效
		/// </summary>
		[JsonProperty("parent_id")]
		public string ParentID { get; set; }

		/// <summary>
		/// 子频道私密类型
		/// </summary>
		[JsonProperty("private_type")]
		public PrivateType PrivateType { get; set; }

		/// <summary>
		/// 子频道私密类型成员 ID
		/// </summary>
		[JsonProperty("private_user_ids")]
		public List<string> PrivateUserIDs { get; set; }

		/// <summary>
		/// 子频道发言权限
		/// </summary>
		[JsonProperty("speak_permission")]
		public SpeakPermission SpeakPermission { get; set; }

		/// <summary>
		/// 用于标识应用子频道应用类型，仅应用子频道时会使用该字段，具体定义请参考 <a href="https://bot.q.qq.com/wiki/develop/api-v2/server-inter/channel/manage/channel/model.html#%E5%BA%94%E7%94%A8%E5%AD%90%E9%A2%91%E9%81%93%E7%9A%84%E5%BA%94%E7%94%A8%E7%B1%BB%E5%9E%8B">应用子频道的应用类型</a>
		/// </summary>
		[JsonProperty("application_id")]
		public string ApplicationID { get; set; }
	}
}
