using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// 获取消息表情表态的用户列表结果
	/// </summary>
	public class ReactionRes
	{
		/// <summary>
		/// 用户对象，参考 User，会返回 id, username, avatar
		/// </summary>
		[JsonProperty("users")]
		public List<User> Users { get; set; }

		/// <summary>
		/// 分页参数，用于拉取下一页
		/// </summary>
		[JsonProperty("cookie")]
		public string Cookie { get; set; }

		/// <summary>
		/// 是否已拉取完成到最后一页，true代表完成
		/// </summary>
		[JsonProperty("is_end")]
		public bool IsEnd { get; set; }
	}
}
