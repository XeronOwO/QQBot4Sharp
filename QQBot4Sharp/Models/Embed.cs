using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// 消息嵌入
    /// </summary>
    public class Embed
    {
        /// <summary>
        /// 标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 消息弹窗内容
        /// </summary>
        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        [JsonProperty("thumbnail")]
        public EmbedThumbnail Thumbnail { get; set; }

        /// <summary>
        /// 嵌入字段数据
        /// </summary>
        [JsonProperty("fields")]
        public List<EmbedField> Fields { get; set; }
    }
}
