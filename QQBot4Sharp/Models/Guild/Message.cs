using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// 消息对象
	/// </summary>
	public class Message
	{
		/// <summary>
		/// 消息ID
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }

		/// <summary>
		/// 子频道ID
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelID { get; set; }

		/// <summary>
		/// 频道ID
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildID { get; set; }

		/// <summary>
		/// 消息内容
		/// </summary>
		[JsonProperty("content")]
		public string Content { get; set; }

		/// <summary>
		/// 消息创建时间
		/// </summary>
		[JsonProperty("timestamp")]
		public DateTime Timestamp { get; set; }

		/// <summary>
		/// 消息编辑时间
		/// </summary>
		[JsonProperty("edited_timestamp")]
		public DateTime EditedTimestamp { get; set; }

		/// <summary>
		/// 是否是@全员消息
		/// </summary>
		[JsonProperty("mention_everyone")]
		public bool MentionEveryone { get; set; }

		/// <summary>
		/// 消息创建者
		/// </summary>
		[JsonProperty("author")]
		public User Author { get; set; }

		/// <summary>
		/// 附件
		/// </summary>
		[JsonProperty("attachments")]
		public List<Attachment> Attachments { get; set; }

		/// <summary>
		/// 消息嵌入
		/// </summary>
		[JsonProperty("embeds")]
		public List<Embed> Embeds { get; set; }

		/// <summary>
		/// 消息中@的人
		/// </summary>
		[JsonProperty("mentions")]
		public List<User> Mentions { get; set; }

		/// <summary>
		/// 消息创建者的<see cref="Guild.Member"/>信息
		/// </summary>
		[JsonProperty("member")]
		public Member Member { get; set; }

		/// <summary>
		/// Ark消息
		/// </summary>
		[JsonProperty("ark")]
		public Ark Ark { get; set; }

		/// <summary>
		/// 用于消息间的排序，Seq 在同一子频道中按从先到后的顺序递增，不同的子频道之间消息无法排序。(目前只在消息事件中有值，(2022年8月1日) 后续废弃)
		/// </summary>
		[JsonProperty("seq")]
		public int Seq { get; set; }

		/// <summary>
		/// 子频道消息 Seq，用于消息间的排序，Seq 在同一子频道中按从先到后的顺序递增，不同的子频道之间消息无法排序
		/// </summary>
		[JsonProperty("seq_in_channel")]
		public string SeqInChannel { get; set; }

		/// <summary>
		/// 引用消息对象
		/// </summary>
		[JsonProperty("message_reference")]
		public MessageReference MessageReference { get; set; }
	}
}
