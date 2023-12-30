using QQBot4Sharp.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 子频道更新事件参数
	/// </summary>
	public class ChannelUpdateEventArgs : ContextEventArgs
	{
		/// <summary>
		/// 子频道事件信息
		/// </summary>
		public ChannelEventData Channel { get; }

		internal ChannelUpdateEventArgs(BotContext botContext, ChannelEventData channel) : base(botContext)
		{
			Channel = channel;
		}
	}
}
