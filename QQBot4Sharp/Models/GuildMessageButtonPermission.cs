using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// 消息按钮权限
    /// </summary>
    public enum GuildMessageButtonPermission
    {
        /// <summary>
        /// 指定用户可操作
        /// </summary>
        SpecifiedUser = 0,
        /// <summary>
        /// 仅管理者可操作
        /// </summary>
        Administrator = 1,
        /// <summary>
        /// 所有人可操作
        /// </summary>
        Everyone = 2,
        /// <summary>
        /// 指定身份组可操作（仅频道可用）
        /// </summary>
        SpecifiedRole = 3,
    }
}
