using QQBot4Sharp.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.QQ
{
	/// <summary>
	/// 基本QQ消息事件参数
	/// </summary>
	public class MessageBaseEventArgs : ContextEventArgs
	{
		/// <summary>
		/// 消息
		/// </summary>
		public MessageRecv Message { get; }

		internal MessageBaseEventArgs(BotContext botContext, MessageRecv message) : base(botContext)
		{
			Message = message;
		}
	}
}
