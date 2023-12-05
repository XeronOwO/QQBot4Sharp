using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Utils
{
	/// <summary>
	/// 频道消息帮助类，可以转义/逆转义消息
	/// </summary>
	public static class GuildMessageHelper
	{
		private static readonly Dictionary<string, string> _escapeMap = new()
		{
			{ "&", "&amp;" },
			{ "<", "&lt;" },
			{ ">", "&gt;" },
		};

		/// <summary>
		/// 转义
		/// </summary>
		/// <param name="data">内容</param>
		/// <returns>转义后的内容</returns>
		public static string Escape(string data)
		{
			foreach (var kv in _escapeMap)
			{
				data = data.Replace(kv.Key, kv.Value);
			}
			return data;
		}

		/// <summary>
		/// 逆转义
		/// </summary>
		/// <param name="data">内容</param>
		/// <returns>逆转义后的内容</returns>
		public static string Unescape(string data)
		{
			foreach (var kv in _escapeMap)
			{
				data = data.Replace(kv.Value, kv.Key);
			}
			return data;
		}
	}
}
