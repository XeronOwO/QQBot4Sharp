using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// 成员对象
	/// </summary>
	public class Member
	{
		/// <summary>
		/// 用户的频道基础信息，只有成员相关接口中会填充此信息
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }

		/// <summary>
		/// 用户的昵称
		/// </summary>
		[JsonProperty("nick")]
		public string Nick { get; set; }

		/// <summary>
		/// 用户在频道内的身份组ID
		/// </summary>
		[JsonProperty("roles")]
		public List<string> Roles { get; set; }

		/// <summary>
		/// 用户加入频道的时间
		/// </summary>
		[JsonProperty("joined_at")]
		public DateTime JoinedAt { get; set; }
	}
}
