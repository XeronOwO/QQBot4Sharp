using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// 消息嵌入缩略图
    /// </summary>
    public class EmbedThumbnail
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
