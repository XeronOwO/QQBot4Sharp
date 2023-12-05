using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// 消息附件
	/// </summary>
	public class Attachment
	{
		/// <summary>
		/// 下载地址
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
