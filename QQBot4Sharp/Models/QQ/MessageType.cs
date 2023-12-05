using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.QQ
{
	/// <summary>
	/// QQ消息类型
	/// </summary>
	public enum MessageType
	{
		/// <summary>
		/// 文本
		/// </summary>
		Text = 0,
		/// <summary>
		/// 图文混排
		/// </summary>
		ImageAndText = 1,
		/// <summary>
		/// MarkDown
		/// </summary>
		MarkDown = 2,
		/// <summary>
		/// Ark
		/// </summary>
		Ark = 3,
		/// <summary>
		/// Embed
		/// </summary>
		Embed = 4,
		/// <summary>
		/// 富媒体
		/// </summary>
		Media = 7,
	}
}
