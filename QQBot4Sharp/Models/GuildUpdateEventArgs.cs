using QQBot4Sharp.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 频道更新事件参数
	/// </summary>
	public class GuildUpdateEventArgs : ContextEventArgs
	{
		/// <summary>
		/// 频道事件信息
		/// </summary>
		public GuildEventData Guild { get; }

		internal GuildUpdateEventArgs(BotContext botContext, GuildEventData guild) : base(botContext)
		{
			Guild = guild;
		}
	}
}
