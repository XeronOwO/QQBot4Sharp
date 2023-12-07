using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// 私信会话创建信息
    /// </summary>
    public class DirectMessageSessionCreateInfo
    {
        /// <summary>
        /// 接收者ID
        /// </summary>
        [JsonProperty("recipient_id")]
        public string RecipientID { get; set; }

        /// <summary>
        /// 源频道ID
        /// </summary>
        [JsonProperty("source_guild_id")]
        public string SourceGuildID { get; set; }

        /// <summary>
        /// 创建私信会话创建信息
        /// </summary>
        public DirectMessageSessionCreateInfo() { }

        /// <summary>
        /// 创建私信会话创建信息
        /// </summary>
        /// <param name="recipientID">接收者ID</param>
        /// <param name="sourceGuildID">源频道ID</param>
        public DirectMessageSessionCreateInfo(string recipientID, string sourceGuildID)
        {
            RecipientID = recipientID;
            SourceGuildID = sourceGuildID;
        }
    }
}
