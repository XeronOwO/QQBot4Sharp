using QQBot4Sharp.Internal;
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

		/// <inheritdoc cref="BotService.SendChannelMessageAsync(GuildMessageReq, string)"/>
		public async Task<GuildMessage> SendChannelMessageAsync(GuildMessageReq message, string channalID)
			=> await BotContext.SendChannelMessageAsync(message, channalID);

		/// <inheritdoc cref="BotService.SendDirectMessageAsync(GuildMessageReq, string)"/>
		public async Task<GuildMessage> SendDirectMessageAsync(GuildMessageReq message, string guildID)
			=> await BotContext.SendDirectMessageAsync(message, guildID);

		/// <inheritdoc cref="BotService.CreateDirectMessageSessionAsync(DirectMessageSessionCreateInfo)"/>
		public async Task<DirectMessageSession> CreateDirectMessageSessionAsync(DirectMessageSessionCreateInfo info)
			=> await BotContext.CreateDirectMessageSessionAsync(info);

		/// <inheritdoc cref="BotService.DeleteChannelMessageAsync(string, string, bool)"/>
		public async Task DeleteChannelMessageAsync(string channelID, string messageID, bool hideTip = false)
			=> await BotContext.DeleteChannelMessageAsync(channelID, messageID, hideTip);

		/// <inheritdoc cref="BotService.DeleteChannelMessageAsync(GuildMessage, bool)"/>
		public async Task DeleteChannelMessageAsync(GuildMessage message, bool hideTip = false)
			=> await BotContext.DeleteChannelMessageAsync(message.ChannelID, message.ID, hideTip);

		/// <inheritdoc cref="BotService.DeleteDirectMessageAsync(string, string, bool)"/>
		public async Task DeleteDirectMessageAsync(string guildID, string messageID, bool hideTip = false)
			=> await BotContext.DeleteDirectMessageAsync(guildID, messageID, hideTip);

		/// <inheritdoc cref="BotService.DeleteDirectMessageAsync(GuildMessage, bool)"/>
		public async Task DeleteDirectMessageAsync(GuildMessage message, bool hideTip = false)
			=> await BotContext.DeleteDirectMessageAsync(message.GuildID, message.ID, hideTip);

		/// <inheritdoc cref="BotService.SendUserMessageAsync(QQMessageReq, string)"/>
		public async Task<QQMessageRes> SendUserMessageAsync(QQMessageReq message, string openID)
			=> await BotContext.SendUserMessageAsync(message, openID);

		/// <inheritdoc cref="BotService.SendGroupMessageAsync(QQMessageReq, string)"/>
		public async Task<QQMessageRes> SendGroupMessageAsync(QQMessageReq message, string groupOpenID)
			=> await BotContext.SendGroupMessageAsync(message, groupOpenID);

		/// <inheritdoc cref="BotService.UploadUserMediaAsync(MediaReq, string)"/>
		public async Task<MediaRes> UploadUserMediaAsync(MediaReq media, string openID)
			=> await BotContext.UploadUserMediaAsync(media, openID);

		/// <inheritdoc cref="BotService.UploadGroupMediaAsync(MediaReq, string)"/>
		public async Task<MediaRes> UploadGroupMediaAsync(MediaReq media, string groupOpenID)
			=> await BotContext.UploadGroupMediaAsync(media, groupOpenID);

		/// <inheritdoc cref="BotService.SetEmojiReactionAsync(string, string, EmojiType, string)"/>
		public async Task SetEmojiReactionAsync(string channelID, string messageID, EmojiType type, string emojiID)
			=> await BotContext.SetEmojiReactionAsync(channelID, messageID, type, emojiID);

		/// <inheritdoc cref="BotService.SetEmojiReactionAsync(GuildMessage, EmojiType, string)"/>
		public async Task SetEmojiReactionAsync(GuildMessage message, EmojiType type, string emojiID)
			=> await BotContext.SetEmojiReactionAsync(message.ChannelID, message.ID, type, emojiID);

		/// <inheritdoc cref="BotService.SetEmojiReactionAsync(string, string, Emoji)"/>
		public async Task SetEmojiReactionAsync(string channelID, string messageID, Emoji emoji)
			=> await BotContext.SetEmojiReactionAsync(channelID, messageID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.SetEmojiReactionAsync(GuildMessage, Emoji)"/>
		public async Task SetEmojiReactionAsync(GuildMessage message, Emoji emoji)
			=> await BotContext.SetEmojiReactionAsync(message.ChannelID, message.ID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.DeleteEmojiReactionAsync(string, string, EmojiType, string)"/>
		public async Task DeleteEmojiReactionAsync(string channelID, string messageID, EmojiType type, string emojiID)
			=> await BotContext.DeleteEmojiReactionAsync(channelID, messageID, type, emojiID);

		/// <inheritdoc cref="BotService.DeleteEmojiReactionAsync(GuildMessage, EmojiType, string)"/>
		public async Task DeleteEmojiReactionAsync(GuildMessage message, EmojiType type, string emojiID)
			=> await BotContext.DeleteEmojiReactionAsync(message.ChannelID, message.ID, type, emojiID);

		/// <inheritdoc cref="BotService.DeleteEmojiReactionAsync(string, string, Emoji)"/>
		public async Task DeleteEmojiReactionAsync(string channelID, string messageID, Emoji emoji)
			=> await BotContext.DeleteEmojiReactionAsync(channelID, messageID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.DeleteEmojiReactionAsync(GuildMessage, Emoji)"/>
		public async Task DeleteEmojiReactionAsync(GuildMessage message, Emoji emoji)
			=> await BotContext.DeleteEmojiReactionAsync(message.ChannelID, message.ID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.GetEmojiReactionAsync(string, string, EmojiType, string)"/>
		public async Task<List<GuildUser>> GetEmojiReactionAsync(string channelID, string messageID, EmojiType type, string emojiID)
			=> await BotContext.GetEmojiReactionAsync(channelID, messageID, type, emojiID);

		/// <inheritdoc cref="BotService.GetEmojiReactionAsync(GuildMessage, EmojiType, string)"/>
		public async Task<List<GuildUser>> GetEmojiReactionAsync(GuildMessage message, EmojiType type, string emojiID)
			=> await BotContext.GetEmojiReactionAsync(message.ChannelID, message.ID, type, emojiID);

		/// <inheritdoc cref="BotService.GetEmojiReactionAsync(string, string, Emoji)"/>
		public async Task<List<GuildUser>> GetEmojiReactionAsync(string channelID, string messageID, Emoji emoji)
			=> await BotContext.GetEmojiReactionAsync(channelID, messageID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.GetEmojiReactionAsync(GuildMessage, Emoji)"/>
		public async Task<List<GuildUser>> GetEmojiReactionAsync(GuildMessage message, Emoji emoji)
			=> await BotContext.GetEmojiReactionAsync(message.ChannelID, message.ID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.RespondToInteractionAsync(string)"/>
		public async Task RespondToInteractionAsync(string interactionID)
			=> await BotContext.RespondToInteractionAsync(interactionID);
	}
}
