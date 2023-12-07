using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// 表情对象<br/><a href="https://bot.q.qq.com/wiki/develop/api-v2/openapi/emoji/model.html#emoji%E5%88%97%E8%A1%A8">Emoji列表</a>
    /// </summary>
    public class Emoji
    {
        /// <summary>
        /// 表情ID，系统表情使用数字为ID，emoji使用emoji本身为id<br/>详见：<a href="https://bot.q.qq.com/wiki/develop/api-v2/openapi/emoji/model.html#emoji%E5%88%97%E8%A1%A8">Emoji列表</a>
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 表情类型 EmojiType
        /// </summary>
        [JsonProperty("type")]
        public EmojiType Type { get; set; }
    }
}
