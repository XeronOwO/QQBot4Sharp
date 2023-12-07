using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// 表情表态对象
    /// </summary>
    public class GuildMessageReaction
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [JsonProperty("user_id")]
        public string UserID { get; set; }

        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonProperty("guild_id")]
        public string GuildID { get; set; }

        /// <summary>
        /// 子频道ID
        /// </summary>
        [JsonProperty("channel_id")]
        public string ChannelID { get; set; }

        /// <summary>
        /// 表态对象
        /// </summary>
        [JsonProperty("target")]
        public ReactionTarget Target { get; set; }

        /// <summary>
        /// 表态所用表情
        /// </summary>
        [JsonProperty("emoji")]
        public Emoji Emoji { get; set; }
    }
}
