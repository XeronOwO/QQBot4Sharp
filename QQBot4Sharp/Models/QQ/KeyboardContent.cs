using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.QQ
{
	/// <summary>
	/// 消息交互内容
	/// </summary>
	public class KeyboardContent
	{
		/// <summary>
		/// 消息交互内容行列表
		/// </summary>
		[JsonProperty("rows")]
		public List<KeyboardContentRow> Rows;
	}
}
