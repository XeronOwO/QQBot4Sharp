using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// 表态对象
    /// </summary>
    public class ReactionTarget
    {
        /// <summary>
        /// 表态对象ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 表态对象类型
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
