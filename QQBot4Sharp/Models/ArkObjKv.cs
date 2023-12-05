using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 消息Ark对象键值对
	/// </summary>
	public class ArkObjKv
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
	}
}
