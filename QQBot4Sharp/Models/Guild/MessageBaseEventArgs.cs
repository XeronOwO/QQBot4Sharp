using QQBot4Sharp.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// 基本消息事件参数
	/// </summary>
	public class MessageBaseEventArgs : ContextEventArgs
	{
		/// <summary>
		/// 消息
		/// </summary>
		public Message Message { get; }

		internal MessageBaseEventArgs(BotContext botContext, Message message) : base(botContext)
		{
			Message = message;
		}
	}
}
