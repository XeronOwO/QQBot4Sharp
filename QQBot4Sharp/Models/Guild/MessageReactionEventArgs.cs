using QQBot4Sharp.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// 消息表态事件参数
	/// </summary>
	public class MessageReactionEventArgs : ContextEventArgs
	{
		/// <summary>
		/// 消息表态
		/// </summary>
		public MessageReaction MessageReaction { get; }

		internal MessageReactionEventArgs(BotContext botContext, MessageReaction messageReaction) : base(botContext)
		{
			MessageReaction = messageReaction;
		}
	}
}
