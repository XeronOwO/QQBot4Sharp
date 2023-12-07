using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// 用户对象<br/>用户对象中所涉及的 ID 类数据，都仅在机器人场景流通，与真实的 ID 无关。请不要理解为真实的 ID
    /// </summary>
    public class GuildUser
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// 用户头像地址
        /// </summary>
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// 是否是机器人
        /// </summary>
        [JsonProperty("bot")]
        public bool IsBot { get; set; }

        /// <summary>
        /// 特殊关联应用的 openid，需要特殊申请并配置后才会返回。如需申请，请联系平台运营人员。
        /// </summary>
        [JsonProperty("union_openid")]
        public string UnionOpenID { get; set; }

        /// <summary>
        /// 机器人关联的互联应用的用户信息，与union_openid关联的应用是同一个。如需申请，请联系平台运营人员。
        /// </summary>
        [JsonProperty("union_user_account")]
        public string UnionUserAccount { get; set; }
    }
}
