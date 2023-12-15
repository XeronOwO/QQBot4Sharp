using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 子频道子类型
	/// </summary>
	public enum ChannelSubType
	{
		/// <summary>
		/// 闲聊
		/// </summary>
		Chat = 0,
		/// <summary>
		/// 公告
		/// </summary>
		Notice = 1,
		/// <summary>
		/// 攻略
		/// </summary>
		Guide = 2,
		/// <summary>
		/// 开黑
		/// </summary>
		Voice = 3,
	}
}
