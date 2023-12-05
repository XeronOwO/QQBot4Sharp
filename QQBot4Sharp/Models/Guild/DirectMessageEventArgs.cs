using QQBot4Sharp.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// 私信消息事件参数
	/// </summary>
	public class DirectMessageEventArgs : MessageBaseEventArgs
	{
		internal DirectMessageEventArgs(BotContext botContext, Message message) : base(botContext, message)
		{
		}

		/// <summary>
		/// 快速回复消息<br/>注意：如果消息需要审核，会抛出异常，详见 <a href="https://bot.q.qq.com/wiki/develop/api/openapi/error/error.html#%E9%94%99%E8%AF%AF%E7%A0%81%E5%A4%84%E7%90%86">错误码处理</a> 304023与304024
		/// </summary>
		/// <param name="message">要发送的消息</param>
		/// <param name="setMessageIDAuto">是否自动设置消息ID。如果不设置消息ID，会被视为推送消息，并占用推送消息额度（私域除外）</param>
		/// <returns>消息对象</returns>
		public async Task<Message> ReplyAsync(MessageReq message, bool setMessageIDAuto = true)
		{
			if (setMessageIDAuto)
			{
				message.MessageID = Message.ID;
			}
			return await SendDirectMessageAsync(message, Message.GuildID);
		}
	}
}
