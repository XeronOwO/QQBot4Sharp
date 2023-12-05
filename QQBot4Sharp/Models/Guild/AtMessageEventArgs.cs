using QQBot4Sharp.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// At消息事件参数
	/// </summary>
	public class AtMessageEventArgs : MessageEventArgs
	{
		internal AtMessageEventArgs(BotContext botContext, Message message) : base(botContext, message)
		{
		}
	}
}
