using QQBot4Sharp.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
    /// <summary>
    /// MarkDown构造器
    /// </summary>
    public class MarkDownBuilder
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
        public MarkDownBuilder Raw(string data)
        {
            _sb.Append(data);
            return this;
        }

        /// <summary>
        /// 添加文本
        /// </summary>
        /// <param name="data">内容</param>
        /// <returns>消息构造器</returns>
        public MarkDownBuilder Text(string data)
        {
            _sb.Append(GuildMessageHelper.Escape(data));
            return this;
        }

        /// <summary>
        /// 添加 @某人 消息<br/>解析为 @用户 标签
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>消息构造器</returns>
        public MarkDownBuilder At(string id)
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
        public MarkDownBuilder AtAll()
        {
            _sb.Append("@everyone");
            return this;
        }

        /// <summary>
        /// 添加子频道引用消息<br/>解析为 #子频道 标签，点击可以跳转至子频道，仅支持当前频道内的子频道
        /// </summary>
        /// <param name="id">频道ID</param>
        /// <returns>消息构造器</returns>
        public MarkDownBuilder Channel(string id)
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
        public MarkDownBuilder Emoji(string id)
        {
            _sb.Append("<emoji:");
            _sb.Append(id);
            _sb.Append(">");
            return this;
        }

        /// <summary>
        /// 添加命令消息<br/>采用格式：&lt;cmd reply=true cmd="/参数指令（带引用本消息）"&gt;
        /// </summary>
        /// <param name="name">命令名称（不会自动转义，需手动转义）</param>
        /// <param name="enter">是否发出信息</param>
        /// <param name="reply">是否引用原消息</param>
        /// <returns>MarkDown构造器</returns>
        public MarkDownBuilder Command(string name, bool enter = true, bool reply = false)
        {
            _sb.Append("<cmd enter=");
            _sb.Append(enter);
            _sb.Append(" reply=");
            _sb.Append(reply);
            _sb.Append(" cmd=\"");
            _sb.Append(name);
            _sb.Append("\">");
            return this;
        }

        /// <summary>
        /// 构建MarkDown对象
        /// </summary>
        /// <returns>MarkDown</returns>
        public MarkDown Build()
        {
            return new()
            {
                Content = ToString(),
            };
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}
