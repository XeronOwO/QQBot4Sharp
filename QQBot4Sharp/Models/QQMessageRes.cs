using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// QQ消息结果
    /// </summary>
    public class QQMessageRes
    {
        /// <summary>
        /// 消息唯一ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
    }
}
