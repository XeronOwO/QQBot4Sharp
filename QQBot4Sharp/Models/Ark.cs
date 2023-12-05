using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 消息Ark
	/// </summary>
	public class Ark
	{
		/// <summary>
		/// 模版ID，管理端可获得或内邀申请获得<br/>
		/// 以下默认可使用：<br/>
		/// <a href="https://bot.q.qq.com/wiki/develop/api-v2/server-inter/message/type/template/template_23.html">23 链接+文本列表模板|QQ机器人文档</a><br/>
		/// <a href="https://bot.q.qq.com/wiki/develop/api-v2/server-inter/message/type/template/template_24.html">24 文本+缩略图模板|QQ机器人文档</a><br/>
		/// <a href="https://bot.q.qq.com/wiki/develop/api-v2/server-inter/message/type/template/template_37.html">37 大图模板|QQ机器人文档</a>
		/// </summary>
		[JsonProperty("template_id")]
		public int TemplateID { get; set; }

		/// <summary>
		/// 消息Ark键值对表
		/// </summary>
		[JsonProperty("kv")]
		public List<ArkKv> KeyValues { get; set; }
	}
}
