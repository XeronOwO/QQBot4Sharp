using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.QQ
{
	/// <summary>
	/// 富媒体消息
	/// </summary>
	public class MediaReq
	{
		/// <summary>
		/// （必填）媒体类型
		/// </summary>
		[JsonProperty("file_type")]
		public MediaType FileType { get; set; }

		/// <summary>
		/// （必填）需要发送媒体资源的Url
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; }

		/// <summary>
		/// （必填）设置 true 会直接发送消息到目标端，且会占用主动消息频次
		/// </summary>
		[JsonProperty("srv_send_msg")]
		public bool ServeSendMessage { get; set; }

		/// <summary>
		/// （选填）【暂未支持】
		/// </summary>
		[JsonProperty("file_data")]
		public object FileData { get; set; }
	}
}
