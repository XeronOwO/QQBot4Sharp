using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// QQ消息附件
    /// </summary>
    public class QQAttachment
    {
        /// <summary>
        /// 内容类型
        /// </summary>
        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        [JsonProperty("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        [JsonProperty("height")]
        public string Height { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        [JsonProperty("width")]
        public string Width { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
