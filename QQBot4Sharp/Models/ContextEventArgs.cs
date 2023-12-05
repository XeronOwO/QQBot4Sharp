using QQBot4Sharp.Internal;
using QQBot4Sharp.Models.Guild;
using QQBot4Sharp.Models.QQ;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QQBot4Sharp.Models
{
	/// <summary>
	/// 上下文事件参数
	/// </summary>
	public class ContextEventArgs : EventArgs
	{
		internal BotContext BotContext { get; }

		/// <summary>
		/// 机器人服务
		/// </summary>
		public BotService Service => BotContext.Service;

		internal ContextEventArgs(BotContext botContext)
		{
			BotContext = botContext;
		}

		/// <inheritdoc cref="BotService.SendChannelMessageAsync(Guild.MessageReq, string)"/>
		public async Task<Message> SendChannelMessageAsync(Guild.MessageReq message, string channalID)
			=> await BotContext.SendChannelMessageAsync(message, channalID);

		/// <inheritdoc cref="BotService.SendDirectMessageAsync(Guild.MessageReq, string)"/>
		public async Task<Message> SendDirectMessageAsync(Guild.MessageReq message, string guildID)
			=> await BotContext.SendDirectMessageAsync(message, guildID);

		/// <inheritdoc cref="BotService.CreateDirectMessageSessionAsync(DirectMessageSessionCreateInfo)"/>
		public async Task<DirectMessageSession> CreateDirectMessageSessionAsync(DirectMessageSessionCreateInfo info)
			=> await BotContext.CreateDirectMessageSessionAsync(info);

		/// <inheritdoc cref="BotService.DeleteChannelMessageAsync(string, string, bool)"/>
		public async Task DeleteChannelMessageAsync(string channelID, string messageID, bool hideTip = false)
			=> await BotContext.DeleteChannelMessageAsync(channelID, messageID, hideTip);

		/// <inheritdoc cref="BotService.DeleteChannelMessageAsync(Message, bool)"/>
		public async Task DeleteChannelMessageAsync(Message message, bool hideTip = false)
			=> await BotContext.DeleteChannelMessageAsync(message.ChannelID, message.ID, hideTip);

		/// <inheritdoc cref="BotService.DeleteDirectMessageAsync(string, string, bool)"/>
		public async Task DeleteDirectMessageAsync(string guildID, string messageID, bool hideTip = false)
			=> await BotContext.DeleteDirectMessageAsync(guildID, messageID, hideTip);

		/// <inheritdoc cref="BotService.DeleteDirectMessageAsync(Message, bool)"/>
		public async Task DeleteDirectMessageAsync(Message message, bool hideTip = false)
			=> await BotContext.DeleteDirectMessageAsync(message.GuildID, message.ID, hideTip);

		/// <inheritdoc cref="BotService.SendUserMessageAsync(QQ.MessageReq, string)"/>
		public async Task<MessageRes> SendUserMessageAsync(QQ.MessageReq message, string openID)
			=> await BotContext.SendUserMessageAsync(message, openID);

		/// <inheritdoc cref="BotService.SendGroupMessageAsync(QQ.MessageReq, string)"/>
		public async Task<MessageRes> SendGroupMessageAsync(QQ.MessageReq message, string groupOpenID)
			=> await BotContext.SendGroupMessageAsync(message, groupOpenID);

		/// <inheritdoc cref="BotService.UploadUserMedia(MediaReq, string)"/>
		public async Task<MediaRes> UploadUserMedia(MediaReq media, string openID)
			=> await BotContext.UploadUserMedia(media, openID);

		/// <inheritdoc cref="BotService.UploadGroupMedia(MediaReq, string)"/>
		public async Task<MediaRes> UploadGroupMedia(MediaReq media, string groupOpenID)
			=> await BotContext.UploadGroupMedia(media, groupOpenID);

		/// <inheritdoc cref="BotService.SetEmojiReactionAsync(string, string, EmojiType, string)"/>
		public async Task SetEmojiReactionAsync(string channelID, string messageID, EmojiType type, string emojiID)
			=> await BotContext.SetEmojiReactionAsync(channelID, messageID, type, emojiID);

		/// <inheritdoc cref="BotService.SetEmojiReactionAsync(Message, EmojiType, string)"/>
		public async Task SetEmojiReactionAsync(Message message, EmojiType type, string emojiID)
			=> await BotContext.SetEmojiReactionAsync(message.ChannelID, message.ID, type, emojiID);

		/// <inheritdoc cref="BotService.SetEmojiReactionAsync(string, string, Emoji)"/>
		public async Task SetEmojiReactionAsync(string channelID, string messageID, Emoji emoji)
			=> await BotContext.SetEmojiReactionAsync(channelID, messageID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.SetEmojiReactionAsync(Message, Emoji)"/>
		public async Task SetEmojiReactionAsync(Message message, Emoji emoji)
			=> await BotContext.SetEmojiReactionAsync(message.ChannelID, message.ID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.DeleteEmojiReactionAsync(string, string, EmojiType, string)"/>
		public async Task DeleteEmojiReactionAsync(string channelID, string messageID, EmojiType type, string emojiID)
			=> await BotContext.DeleteEmojiReactionAsync(channelID, messageID, type, emojiID);

		/// <inheritdoc cref="BotService.DeleteEmojiReactionAsync(Message, EmojiType, string)"/>
		public async Task DeleteEmojiReactionAsync(Message message, EmojiType type, string emojiID)
			=> await BotContext.DeleteEmojiReactionAsync(message.ChannelID, message.ID, type, emojiID);

		/// <inheritdoc cref="BotService.DeleteEmojiReactionAsync(string, string, Emoji)"/>
		public async Task DeleteEmojiReactionAsync(string channelID, string messageID, Emoji emoji)
			=> await BotContext.DeleteEmojiReactionAsync(channelID, messageID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.DeleteEmojiReactionAsync(Message, Emoji)"/>
		public async Task DeleteEmojiReactionAsync(Message message, Emoji emoji)
			=> await BotContext.DeleteEmojiReactionAsync(message.ChannelID, message.ID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.GetEmojiReactionAsync(string, string, EmojiType, string)"/>
		public async Task<List<Guild.User>> GetEmojiReactionAsync(string channelID, string messageID, EmojiType type, string emojiID)
			=> await BotContext.GetEmojiReactionAsync(channelID, messageID, type, emojiID);

		/// <inheritdoc cref="BotService.GetEmojiReactionAsync(Message, EmojiType, string)"/>
		public async Task<List<Models.Guild.User>> GetEmojiReactionAsync(Message message, EmojiType type, string emojiID)
			=> await BotContext.GetEmojiReactionAsync(message.ChannelID, message.ID, type, emojiID);

		/// <inheritdoc cref="BotService.GetEmojiReactionAsync(string, string, Emoji)"/>
		public async Task<List<Guild.User>> GetEmojiReactionAsync(string channelID, string messageID, Emoji emoji)
			=> await BotContext.GetEmojiReactionAsync(channelID, messageID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.GetEmojiReactionAsync(Message, Emoji)"/>
		public async Task<List<Guild.User>> GetEmojiReactionAsync(Message message, Emoji emoji)
			=> await BotContext.GetEmojiReactionAsync(message.ChannelID, message.ID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.RespondToInteractionAsync(string)"/>
		public async Task RespondToInteractionAsync(string interactionID)
			=> await BotContext.RespondToInteractionAsync(interactionID);
	}
}
