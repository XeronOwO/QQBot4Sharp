using QQBot4Sharp.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// 消息事件参数
    /// </summary>
    public class GuildMessageEventArgs : ReplyEventArgs<GuildMessage, GuildMessageReq, GuildMessage>
	{
		internal GuildMessageEventArgs(BotContext botContext, GuildMessage message) : base(botContext, message)
		{
		}

		/// <inheritdoc/>
		public override async Task<GuildMessage> ReplyAsync(GuildMessageReq req, bool setMessageIDAuto = true)
		{
			if (setMessageIDAuto)
			{
				req.MessageID = Message.ID;
			}
			return await SendChannelMessageAsync(req, Message.ChannelID);
		}
	}
}
