using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 消息引用
	/// </summary>
	public class MessageReference
	{
		/// <summary>
		/// 需要引用回复的消息ID
		/// </summary>
		[JsonProperty("message_id")]
		public string MessageID { get; set; }

		/// <summary>
		/// 是否忽略获取引用消息详情错误，默认否
		/// </summary>
		[JsonProperty("ignore_get_message_error")]
		public bool IgnoreGetMessageError { get; set; }
	}
}
