using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// 消息按钮行为
    /// </summary>
    public enum GuildMessageButtonAction
    {
        /// <summary>
        /// 跳转按钮：http 或 小程序 客户端识别 scheme, data字段为链接
        /// </summary>
        JumpLink = 0,
        /// <summary>
        /// 回调按钮：回调后台接口, data 传给后台
        /// </summary>
        Callback = 1,
        /// <summary>
        /// 指令按钮：自动在输入框插入 @bot data
        /// </summary>
        Command = 2,
    }
}
