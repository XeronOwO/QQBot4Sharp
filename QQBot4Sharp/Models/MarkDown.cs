using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// MarkDown
    /// </summary>
    public class MarkDown
    {
        /// <summary>
        /// （选填）原生MarkDown文本内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// （选填）MarkDown模版ID，申请模版后获得
        /// </summary>
        [JsonProperty("custom_template_id")]
        public string CustomTemplateID { get; set; }

        /// <summary>
        /// （选填）模版内变量与填充值的键值映射
        /// </summary>
        [JsonProperty("params")]
        public List<MarkDownParam> Params { get; set; }
    }
}
