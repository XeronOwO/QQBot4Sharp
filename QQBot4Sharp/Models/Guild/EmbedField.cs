using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// 消息嵌入字段
	/// </summary>
	public class EmbedField
	{
		/// <summary>
		/// 字段名
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
