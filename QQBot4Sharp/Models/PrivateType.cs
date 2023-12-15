using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 子频道私密类型
	/// </summary>
	public enum PrivateType
	{
		/// <summary>
		/// 公开频道
		/// </summary>
		Public = 0,
		/// <summary>
		/// 群主管理员可见
		/// </summary>
		Admin = 1,
		/// <summary>
		/// 群主管理员+指定成员，可使用 修改子频道权限接口 指定成员
		/// </summary>
		AdminAndSpecified = 2,
	}
}
