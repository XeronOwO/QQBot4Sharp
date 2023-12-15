using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 子频道发言权限
	/// </summary>
	public enum SpeakPermission
	{
		/// <summary>
		/// 无效类型
		/// </summary>
		Invalid = 0,
		/// <summary>
		/// 所有人
		/// </summary>
		All = 1,
		/// <summary>
		/// 群主管理员+指定成员，可使用 修改子频道权限接口 指定成员
		/// </summary>
		AdminAndSpecified = 2,
	}
}
