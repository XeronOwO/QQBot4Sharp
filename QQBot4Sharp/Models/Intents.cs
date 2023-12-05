using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 事件订阅Intents
	/// </summary>
	public enum Intents
	{
		/// <summary>
		/// <code>
		/// GUILDS (1 &lt;&lt; 0)<br/>
		///   - GUILD_CREATE           // 当机器人加入新guild时<br/>
		///   - GUILD_UPDATE           // 当guild资料发生变更时<br/>
		///   - GUILD_DELETE           // 当机器人退出guild时<br/>
		///   - CHANNEL_CREATE         // 当channel被创建时<br/>
		///   - CHANNEL_UPDATE         // 当channel被更新时<br/>
		///   - CHANNEL_DELETE         // 当channel被删除时<br/>
		/// </code>
		/// </summary>
		GUILDS = 1 << 0,
		/// <summary>
		/// <code>
		/// GUILD_MEMBERS (1 &lt;&lt; 1)
		///   - GUILD_MEMBER_ADD       // 当成员加入时
		///   - GUILD_MEMBER_UPDATE    // 当成员资料变更时
		///   - GUILD_MEMBER_REMOVE    // 当成员被移除时
		/// </code>
		/// </summary>
		GUILD_MEMBERS = 1 << 1,
		/// <summary>
		/// <code>
		/// GUILD_MESSAGES (1 &lt;&lt; 9)    // 消息事件，仅 *私域* 机器人能够设置此 intents。
		///   - MESSAGE_CREATE         // 发送消息事件，代表频道内的全部消息，而不只是 at 机器人的消息。内容与 AT_MESSAGE_CREATE 相同
		///   - MESSAGE_DELETE         // 删除（撤回）消息事件
		/// </code>
		/// </summary>
		GUILD_MESSAGES = 1 << 9,
		/// <summary>
		/// <code>
		/// GUILD_MESSAGE_REACTIONS (1 &lt;&lt; 10)
		///   - MESSAGE_REACTION_ADD    // 为消息添加表情表态
		///   - MESSAGE_REACTION_REMOVE // 为消息删除表情表态
		/// </code>
		/// </summary>
		GUILD_MESSAGE_REACTIONS = 1 << 10,
		/// <summary>
		/// <code>
		/// DIRECT_MESSAGE (1 &lt;&lt; 12)
		///   - DIRECT_MESSAGE_CREATE   // 当收到用户发给机器人的私信消息时
		///   - DIRECT_MESSAGE_DELETE   // 删除（撤回）消息事件
		/// </code>
		/// </summary>
		DIRECT_MESSAGE = 1 << 12,
		/// <summary>
		/// <code>
		/// INTERACTION (1 &lt;&lt; 26)
		///   - INTERACTION_CREATE     // 互动事件创建时
		/// </code>
		/// </summary>
		INTERACTION = 1 << 26,
		/// <summary>
		/// <code>
		/// MESSAGE_AUDIT (1 &lt;&lt; 27)
		///   - MESSAGE_AUDIT_PASS     // 消息审核通过
		///   - MESSAGE_AUDIT_REJECT   // 消息审核不通过
		/// </code>
		/// </summary>
		MESSAGE_AUDIT = 1 << 27,
		/// <summary>
		/// <code>
		/// FORUMS_EVENT (1 &lt;&lt; 28)  // 论坛事件，仅 *私域* 机器人能够设置此 intents。
		///   - FORUM_THREAD_CREATE     // 当用户创建主题时
		///   - FORUM_THREAD_UPDATE     // 当用户更新主题时
		///   - FORUM_THREAD_DELETE     // 当用户删除主题时
		///   - FORUM_POST_CREATE       // 当用户创建帖子时
		///   - FORUM_POST_DELETE       // 当用户删除帖子时
		///   - FORUM_REPLY_CREATE      // 当用户回复评论时
		///   - FORUM_REPLY_DELETE      // 当用户回复评论时
		///   - FORUM_PUBLISH_AUDIT_RESULT      // 当用户发表审核通过时
		/// </code>
		/// </summary>
		FORUMS_EVENT = 1 << 28,
		/// <summary>
		/// <code>
		/// AUDIO_ACTION (1 &lt;&lt; 29)
		///   - AUDIO_START             // 音频开始播放时
		///   - AUDIO_FINISH            // 音频播放结束时
		///   - AUDIO_ON_MIC            // 上麦时
		///   - AUDIO_OFF_MIC           // 下麦时
		/// </code>
		/// </summary>
		AUDIO_ACTION = 1 << 29,
		/// <summary>
		/// <code>
		/// PUBLIC_GUILD_MESSAGES (1 &lt;&lt; 30) // 消息事件，此为公域的消息事件
		///   - AT_MESSAGE_CREATE       // 当收到@机器人的消息时
		///   - PUBLIC_MESSAGE_DELETE   // 当频道的消息被删除时
		/// </code>
		/// </summary>
		PUBLIC_GUILD_MESSAGES = 1 << 30,

		/// <summary>
		/// 订阅所有事件，包括私域和公域的消息事件
		/// </summary>
		ALL = GUILDS | GUILD_MEMBERS | GUILD_MESSAGES | GUILD_MESSAGE_REACTIONS | DIRECT_MESSAGE | INTERACTION | MESSAGE_AUDIT | FORUMS_EVENT | AUDIO_ACTION | PUBLIC_GUILD_MESSAGES,
		/// <summary>
		/// 订阅所有公域事件，即排除仅私域的事件
		/// </summary>
		ALL_PUBLIC = GUILDS | GUILD_MEMBERS | GUILD_MESSAGE_REACTIONS | DIRECT_MESSAGE | INTERACTION | MESSAGE_AUDIT | AUDIO_ACTION | PUBLIC_GUILD_MESSAGES,
	}
}
