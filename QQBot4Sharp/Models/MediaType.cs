using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// 富媒体消息类型
    /// </summary>
    public enum MediaType
    {
        /// <summary>
        /// 图片（png/jpg）
        /// </summary>
        Image = 1,
        /// <summary>
        /// 视频（mp4）
        /// </summary>
        Vedio = 2,
        /// <summary>
        /// 语音（silk）
        /// </summary>
        Voice = 3,
        /// <summary>
        /// 文件（暂不开放）
        /// </summary>
        File = 4,
    }
}
