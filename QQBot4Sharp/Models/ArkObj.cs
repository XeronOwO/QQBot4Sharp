using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 消息Ark对象
	/// </summary>
	public class ArkObj
	{
		/// <summary>
		/// 消息Ark对象键值对表
		/// </summary>
		[JsonProperty("obj_kv")]
		public List<ArkObjKv> ObjectKeyValues { get; set; }
	}
}
