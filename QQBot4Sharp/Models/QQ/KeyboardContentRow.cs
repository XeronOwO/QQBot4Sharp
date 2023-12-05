using Newtonsoft.Json;
using QQBot4Sharp.Models.Guild;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.QQ
{
	/// <summary>
	/// 消息交互内容行
	/// </summary>
	public class KeyboardContentRow
	{
		/// <summary>
		/// 消息按钮列表
		/// </summary>
		[JsonProperty("buttons")]
		public List<MessageButton> Buttons;
	}
}
