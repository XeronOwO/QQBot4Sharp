using QQBot4Sharp.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 子频道删除事件参数
	/// </summary>
	public class ChannelDeleteEventArgs : ContextEventArgs
	{
		/// <summary>
		/// 子频道事件信息
		/// </summary>
		public ChannelEventData Channel { get; }

		internal ChannelDeleteEventArgs(BotContext botContext, ChannelEventData channel) : base(botContext)
		{
			Channel = channel;
		}
	}
}
