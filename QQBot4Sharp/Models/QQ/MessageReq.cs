using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.QQ
{
    /// <summary>
    /// QQ消息请求
    /// </summary>
    public class MessageReq
	{
		/// <summary>
		/// （选填）文本内容
		/// </summary>
		[JsonProperty("content")]
		public string Content { get; set; }

		/// <summary>
		/// （必填）消息类型
		/// </summary>
		[JsonProperty("msg_type")]
		public MessageType Type { get; set; }

		/// <summary>
		/// （选填）MarkDown
		/// </summary>
		[JsonProperty("markdown")]
		public MarkDown MarkDown { get; set; }

		/// <summary>
		/// （选填）消息交互
		/// </summary>
		[JsonProperty("keyboard")]
		public Keyboard Keyboard { get; set; }

		/// <summary>
		/// （选填）Ark
		/// </summary>
		[JsonProperty("ark")]
		public Ark Ark { get; set; }

		/// <summary>
		/// （选填）富媒体消息
		/// </summary>
		[JsonProperty("media")]
		public MediaRes Media { get; set; }

		/// <summary>
		/// （选填）【暂不支持】
		/// </summary>
		[JsonProperty("image")]
		public string Image { get; set; }

		/// <summary>
		/// （选填）【暂未支持】消息引用
		/// </summary>
		[JsonProperty("message_reference")]
		public MessageReference Reference { get; set; }

		/// <summary>
		/// （选填）【暂未支持】前置收到的事件ID，用于发送被动消息
		/// </summary>
		[JsonProperty("event_id")]
		public string EventID { get; set; }

		/// <summary>
		/// （选填）前置收到的用户发送过来的消息 ID，用于发送被动消息（回复）
		/// </summary>
		[JsonProperty("msg_id")]
		public string MessageID { get; set; }

		/// <summary>
		/// （选填）回复消息的序号，与 msg_id 联合使用，避免相同消息id回复重复发送，不填默认是1。相同的 msg_id + msg_seq 重复发送会失败。
		/// </summary>
		[JsonProperty("msg_seq")]
		public int? MessageSeq { get; set; }
	}
}
