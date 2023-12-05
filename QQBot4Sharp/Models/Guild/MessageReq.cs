using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// 可发送的消息<br/>content, embed, ark, image, markdown 至少需要有一个字段，否则无法下发消息。
	/// </summary>
	public class MessageReq
	{
		/// <summary>
		/// （选填）消息内容，文本内容，支持<a href="https://bot.q.qq.com/wiki/develop/api-v2/server-inter/message/message_format.html">内嵌格式</a><br/>可以使用<see cref="MessageBuilder"/>来构建消息
		/// </summary>
		[JsonProperty("content")]
		public string Content { get; set; }

		/// <summary>
		/// （选填）embed 消息，一种特殊的 ark
		/// </summary>
		[JsonProperty("embed")]
		public Embed Embed { get; set; }

		/// <summary>
		/// （选填）ark 消息
		/// </summary>
		[JsonProperty("ark")]
		public Ark Ark { get; set; }

		/// <summary>
		/// （选填）引用消息
		/// </summary>
		[JsonProperty("message_reference")]
		public MessageReference MessageReference { get; set; }

		/// <summary>
		/// （选填）图片url地址，平台会转存该图片，用于下发图片消息
		/// </summary>
		[JsonProperty("image")]
		public string Image { get; set; }

		/// <summary>
		/// （选填）要回复的消息id(Message.id), 在 AT_CREATE_MESSAGE 事件中获取。
		/// </summary>
		[JsonProperty("msg_id")]
		public string MessageID { get; set; }

		/// <summary>
		/// （选填）markdown 信息
		/// </summary>
		[JsonProperty("markdown")]
		public MarkDown Markdown { get; set; }
	}
}
