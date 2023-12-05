using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// 消息按钮
	/// </summary>
	public class MessageButton
	{
		/// <summary>
		/// （选填）按钮ID：在一个KeyBoard消息内设置唯一
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }

		/// <summary>
		/// （必填）按钮上的文字
		/// </summary>
		[JsonProperty("render_data.label")]
		public string Label { get; set; }

		/// <summary>
		/// （必填）点击后按钮的上文字
		/// </summary>
		[JsonProperty("render_data.visited_label")]
		public string VisitedLabel { get; set; }

		/// <summary>
		/// （必填）按钮样式
		/// </summary>
		[JsonProperty("render_data.style")]
		public MessageButtonStyle Style { get; set; }

		/// <summary>
		/// （必填）按钮行为
		/// </summary>
		[JsonProperty("action.type")]
		public MessageButtonAction Action { get; set; }

		/// <summary>
		/// （必填）操作权限
		/// </summary>
		[JsonProperty("action.permisson.type")]
		public MessageButtonPermission Permission { get; set; }

		/// <summary>
		/// （选填）有权限的身份组ID的列表（仅频道可用）
		/// </summary>
		[JsonProperty("action.permisson.specify_role_ids")]
		public List<string> SpecifiedRoleIDs { get; set; }

		/// <summary>
		/// （选填）有权限的用户ID的列表
		/// </summary>
		[JsonProperty("action.permisson.specify_user_ids")]
		public List<string> SpecifiedUserIDs { get; set; }

		/// <summary>
		/// （必填）操作相关的数据
		/// </summary>
		[JsonProperty("data")]
		public string Data { get; set; }

		/// <summary>
		/// （选填）指令按钮可用，指令是否带引用回复本消息，默认 false。支持版本 8983
		/// </summary>
		[JsonProperty("reply")]
		public bool? Reply { get; set; }

		/// <summary>
		/// （选填）指令按钮可用，点击按钮后直接自动发送 data，默认 false。支持版本 8983
		/// </summary>
		[JsonProperty("enter")]
		public bool? Enter { get; set; }

		/// <summary>
		/// （选填）指令按钮可用，自动锚点到选图器，默认 false，设置 ture 后会忽略 enter 配置。支持版本 8983
		/// </summary>
		[JsonProperty("anchor")]
		public bool? Anchor { get; set; }

		/// <summary>
		/// （选填）可操作点击的次数，默认不限
		/// </summary>
		[JsonProperty("click_limit")]
		public int ClickLimit { get; set; }

		/// <summary>
		/// （必填）客户端不支持本action的时候，弹出的toast文案
		/// </summary>
		[JsonProperty("unsupport_tips")]
		public string UnsupportTips { get; set; }
	}
}
