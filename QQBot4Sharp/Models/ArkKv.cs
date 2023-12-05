using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 消息Ark键值对
	/// </summary>
	public class ArkKv
	{
		/// <summary>
		/// 键
		/// </summary>
		[JsonProperty("key")]
		public string Key { get; set; }

		/// <summary>
		/// 值
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }

		/// <summary>
		/// 消息Ark对象表
		/// </summary>
		[JsonProperty("obj")]
		public List<ArkObj> Objects { get; set; }
	}
}
