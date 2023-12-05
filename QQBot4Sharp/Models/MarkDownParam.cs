using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// MarkDown参数
    /// </summary>
    public class MarkDownParam
    {
        /// <summary>
        /// 键
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// 值表
        /// </summary>
        [JsonProperty("values")]
        public List<string> Values { get; set; }
    }
}
