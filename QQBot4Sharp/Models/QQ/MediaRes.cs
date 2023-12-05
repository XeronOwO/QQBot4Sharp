using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.QQ
{
	/// <summary>
	/// 富媒体消息引用
	/// </summary>
	public class MediaRes
	{
		/// <summary>
		/// 消息信息
		/// </summary>
		[JsonProperty("file_info")]
		public string FileInfo { get; set; }
	}
}
