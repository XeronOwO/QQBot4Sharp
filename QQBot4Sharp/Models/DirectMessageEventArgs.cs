using QQBot4Sharp.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// 私信消息事件参数
    /// </summary>
    public class DirectMessageEventArgs : ReplyEventArgs<GuildMessage, GuildMessageReq, GuildMessage>
    {
        internal DirectMessageEventArgs(BotContext botContext, GuildMessage message) : base(botContext, message)
        {
        }

        /// <inheritdoc/>
		public override async Task<GuildMessage> ReplyAsync(GuildMessageReq req, bool setMessageIDAuto = true)
		{
            if (setMessageIDAuto)
            {
                req.MessageID = Message.ID;
            }
            return await SendDirectMessageAsync(req, Message.GuildID);
		}
	}
}
