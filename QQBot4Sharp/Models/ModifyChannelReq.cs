using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 修改子频道信息
	/// </summary>
	public class ModifyChannelReq
	{
		/// <summary>
		/// 子频道名
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		[JsonProperty("position")]
		public int Position { get; set; }

		/// <summary>
		/// 分组ID
		/// </summary>
		[JsonProperty("parent_id")]
		public string ParentID { get; set; }

		/// <summary>
		/// 子频道私密类型
		/// </summary>
		[JsonProperty("private_type")]
		public PrivateType PrivateType { get; set; }

		/// <summary>
		/// 子频道发言权限
		/// </summary>
		[JsonProperty("speak_permission")]
		public SpeakPermission SpeakPermission { get; set; }
	}
}
