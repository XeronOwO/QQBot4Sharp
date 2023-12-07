using QQBot4Sharp.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// At消息事件参数
    /// </summary>
    public class AtMessageEventArgs : GuildMessageEventArgs
    {
        internal AtMessageEventArgs(BotContext botContext, GuildMessage message) : base(botContext, message)
        {
        }
    }
}
