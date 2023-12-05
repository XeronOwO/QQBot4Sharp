using QQBot4Sharp.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models.Guild
{
	/// <summary>
	/// 消息构造器
	/// </summary>
	public class MessageBuilder
	{
		/// <summary>
		/// 字符串构造器
		/// </summary>
		protected readonly StringBuilder _sb = new();

		/// <summary>
		/// 添加原内容（不进行转义）
		/// </summary>
		/// <param name="data">内容</param>
		/// <returns>消息构造器</returns>
		public MessageBuilder Raw(string data)
		{
			_sb.Append(data);
			return this;
		}

		/// <summary>
		/// 添加文本
		/// </summary>
		/// <param name="data">内容</param>
		/// <returns>消息构造器</returns>
		public MessageBuilder Text(string data)
		{
			_sb.Append(GuildMessageHelper.Escape(data));
			return this;
		}

		/// <summary>
		/// 添加 @某人 消息<br/>解析为 @用户 标签
		/// </summary>
		/// <param name="id">用户ID</param>
		/// <returns>消息构造器</returns>
		public MessageBuilder At(string id)
		{
			_sb.Append("<@");
			_sb.Append(id);
			_sb.Append(">");
			return this;
		}

		/// <summary>
		/// 添加 @全体成员 消息<br/>解析为 @所有人 标签，需要机器人拥有发送 @所有人 消息的权限
		/// </summary>
		/// <returns>消息构造器</returns>
		public MessageBuilder AtAll()
		{
			_sb.Append("@everyone");
			return this;
		}

		/// <summary>
		/// 添加子频道引用消息<br/>解析为 #子频道 标签，点击可以跳转至子频道，仅支持当前频道内的子频道
		/// </summary>
		/// <param name="id">频道ID</param>
		/// <returns>消息构造器</returns>
		public MessageBuilder Channel(string id)
		{
			_sb.Append("<#");
			_sb.Append(id);
			_sb.Append(">");
			return this;
		}

		/// <summary>
		/// 添加表情消息<br/>解析为系统表情，具体表情id参考 <a href="https://bot.q.qq.com/wiki/develop/api-v2/openapi/emoji/model.html#Emoji%E5%88%97%E8%A1%A8">Emoji 列表</a>，仅支持type=1的系统表情，type=2的emoji表情直接按字符串填写即可
		/// </summary>
		/// <param name="id">表情ID</param>
		/// <returns>消息构造器</returns>
		public MessageBuilder Emoji(string id)
		{
			_sb.Append("<emoji:");
			_sb.Append(id);
			_sb.Append(">");
			return this;
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return _sb.ToString();
		}
	}
}
