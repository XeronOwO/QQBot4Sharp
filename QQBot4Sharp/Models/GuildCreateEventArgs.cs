using QQBot4Sharp.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 频道创建事件参数
	/// </summary>
	public class GuildCreateEventArgs : ContextEventArgs
	{
		/// <summary>
		/// 频道事件信息
		/// </summary>
		public GuildEventData Guild { get; }

		internal GuildCreateEventArgs(BotContext botContext, GuildEventData guild) : base(botContext)
		{
			Guild = guild;
		}
	}
}
