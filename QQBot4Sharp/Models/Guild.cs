using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 频道对象
	/// </summary>
	public class Guild
	{
		/// <summary>
		/// 频道ID
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }

		/// <summary>
		/// 频道名称
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 频道头像地址
		/// </summary>
		[JsonProperty("icon")]
		public string Icon { get; set; }

		/// <summary>
		/// 创建人用户ID
		/// </summary>
		[JsonProperty("owner_id")]
		public string OwnerID { get; set; }

		/// <summary>
		/// 当前人是否是创建人
		/// </summary>
		[JsonProperty("owner")]
		public bool IsOwner { get; set; }

		/// <summary>
		/// 成员数
		/// </summary>
		[JsonProperty("member_count")]
		public int MemberCount { get; set; }

		/// <summary>
		/// 最大成员数
		/// </summary>
		[JsonProperty("max_members")]
		public int MaxMembers { get; set; }

		/// <summary>
		/// 描述
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// 加入时间
		/// </summary>
		[JsonProperty("joined_at")]
		public DateTime JoinedAt { get; set; }
	}
}
