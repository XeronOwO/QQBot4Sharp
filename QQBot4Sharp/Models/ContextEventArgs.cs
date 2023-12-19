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
		public Task<GuildMessage> SendChannelMessageAsync(GuildMessageReq message, string channalID)
			=> BotContext.SendChannelMessageAsync(message, channalID);

		/// <inheritdoc cref="BotService.SendDirectMessageAsync(GuildMessageReq, string)"/>
		public Task<GuildMessage> SendDirectMessageAsync(GuildMessageReq message, string guildID)
			=> BotContext.SendDirectMessageAsync(message, guildID);

		/// <inheritdoc cref="BotService.CreateDirectMessageSessionAsync(DirectMessageSessionCreateInfo)"/>
		public Task<DirectMessageSession> CreateDirectMessageSessionAsync(DirectMessageSessionCreateInfo info)
			=> BotContext.CreateDirectMessageSessionAsync(info);

		/// <inheritdoc cref="BotService.DeleteChannelMessageAsync(string, string, bool)"/>
		public Task DeleteChannelMessageAsync(string channelID, string messageID, bool hideTip = false)
			=> BotContext.DeleteChannelMessageAsync(channelID, messageID, hideTip);

		/// <inheritdoc cref="BotService.DeleteChannelMessageAsync(GuildMessage, bool)"/>
		public Task DeleteChannelMessageAsync(GuildMessage message, bool hideTip = false)
			=> BotContext.DeleteChannelMessageAsync(message.ChannelID, message.ID, hideTip);

		/// <inheritdoc cref="BotService.DeleteDirectMessageAsync(string, string, bool)"/>
		public Task DeleteDirectMessageAsync(string guildID, string messageID, bool hideTip = false)
			=> BotContext.DeleteDirectMessageAsync(guildID, messageID, hideTip);

		/// <inheritdoc cref="BotService.DeleteDirectMessageAsync(GuildMessage, bool)"/>
		public Task DeleteDirectMessageAsync(GuildMessage message, bool hideTip = false)
			=> BotContext.DeleteDirectMessageAsync(message.GuildID, message.ID, hideTip);

		/// <inheritdoc cref="BotService.SendUserMessageAsync(QQMessageReq, string)"/>
		public Task<QQMessageRes> SendUserMessageAsync(QQMessageReq message, string openID)
			=> BotContext.SendUserMessageAsync(message, openID);

		/// <inheritdoc cref="BotService.SendGroupMessageAsync(QQMessageReq, string)"/>
		public Task<QQMessageRes> SendGroupMessageAsync(QQMessageReq message, string groupOpenID)
			=> BotContext.SendGroupMessageAsync(message, groupOpenID);

		/// <inheritdoc cref="BotService.UploadUserMediaAsync(MediaReq, string)"/>
		public Task<MediaRes> UploadUserMediaAsync(MediaReq media, string openID)
			=> BotContext.UploadUserMediaAsync(media, openID);

		/// <inheritdoc cref="BotService.UploadGroupMediaAsync(MediaReq, string)"/>
		public Task<MediaRes> UploadGroupMediaAsync(MediaReq media, string groupOpenID)
			=> BotContext.UploadGroupMediaAsync(media, groupOpenID);

		/// <inheritdoc cref="BotService.SetEmojiReactionAsync(string, string, EmojiType, string)"/>
		public Task SetEmojiReactionAsync(string channelID, string messageID, EmojiType type, string emojiID)
			=> BotContext.SetEmojiReactionAsync(channelID, messageID, type, emojiID);

		/// <inheritdoc cref="BotService.SetEmojiReactionAsync(GuildMessage, EmojiType, string)"/>
		public Task SetEmojiReactionAsync(GuildMessage message, EmojiType type, string emojiID)
			=> BotContext.SetEmojiReactionAsync(message.ChannelID, message.ID, type, emojiID);

		/// <inheritdoc cref="BotService.SetEmojiReactionAsync(string, string, Emoji)"/>
		public Task SetEmojiReactionAsync(string channelID, string messageID, Emoji emoji)
			=> BotContext.SetEmojiReactionAsync(channelID, messageID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.SetEmojiReactionAsync(GuildMessage, Emoji)"/>
		public Task SetEmojiReactionAsync(GuildMessage message, Emoji emoji)
			=> BotContext.SetEmojiReactionAsync(message.ChannelID, message.ID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.DeleteEmojiReactionAsync(string, string, EmojiType, string)"/>
		public Task DeleteEmojiReactionAsync(string channelID, string messageID, EmojiType type, string emojiID)
			=> BotContext.DeleteEmojiReactionAsync(channelID, messageID, type, emojiID);

		/// <inheritdoc cref="BotService.DeleteEmojiReactionAsync(GuildMessage, EmojiType, string)"/>
		public Task DeleteEmojiReactionAsync(GuildMessage message, EmojiType type, string emojiID)
			=> BotContext.DeleteEmojiReactionAsync(message.ChannelID, message.ID, type, emojiID);

		/// <inheritdoc cref="BotService.DeleteEmojiReactionAsync(string, string, Emoji)"/>
		public Task DeleteEmojiReactionAsync(string channelID, string messageID, Emoji emoji)
			=> BotContext.DeleteEmojiReactionAsync(channelID, messageID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.DeleteEmojiReactionAsync(GuildMessage, Emoji)"/>
		public Task DeleteEmojiReactionAsync(GuildMessage message, Emoji emoji)
			=> BotContext.DeleteEmojiReactionAsync(message.ChannelID, message.ID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.GetEmojiReactionAsync(string, string, EmojiType, string)"/>
		public Task<List<GuildUser>> GetEmojiReactionAsync(string channelID, string messageID, EmojiType type, string emojiID)
			=> BotContext.GetEmojiReactionAsync(channelID, messageID, type, emojiID);

		/// <inheritdoc cref="BotService.GetEmojiReactionAsync(GuildMessage, EmojiType, string)"/>
		public Task<List<GuildUser>> GetEmojiReactionAsync(GuildMessage message, EmojiType type, string emojiID)
			=> BotContext.GetEmojiReactionAsync(message.ChannelID, message.ID, type, emojiID);

		/// <inheritdoc cref="BotService.GetEmojiReactionAsync(string, string, Emoji)"/>
		public Task<List<GuildUser>> GetEmojiReactionAsync(string channelID, string messageID, Emoji emoji)
			=> BotContext.GetEmojiReactionAsync(channelID, messageID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.GetEmojiReactionAsync(GuildMessage, Emoji)"/>
		public Task<List<GuildUser>> GetEmojiReactionAsync(GuildMessage message, Emoji emoji)
			=> BotContext.GetEmojiReactionAsync(message.ChannelID, message.ID, emoji.Type, emoji.ID);

		/// <inheritdoc cref="BotService.RespondToInteractionAsync(string)"/>
		public Task RespondToInteractionAsync(string interactionID)
			=> BotContext.RespondToInteractionAsync(interactionID);

		/// <inheritdoc cref="BotService.GetCurrentUserAsync"/>
		public Task<GuildUser> GetCurrentUserAsync()
			=> BotContext.GetCurrentUserAsync();

		/// <inheritdoc cref="BotService.GetGuildsAsync"/>"/>
		public Task<List<Guild>> GetGuildsAsync()
			=> BotContext.GetGuildsAsync();

		/// <inheritdoc cref="BotService.GetGuildAsync(string)"/>
		public Task<Guild> GetGuildAsync(string guildID)
			=> BotContext.GetGuildAsync(guildID);

		/// <inheritdoc cref="BotService.GetChannelsAsync(string)"/>
		public Task<List<Channel>> GetChannelsAsync(string guildID)
			=> BotContext.GetChannelsAsync(guildID);

		/// <inheritdoc cref="BotService.GetChannelAsync(string)"/>
		public Task<Channel> GetChannelAsync(string channelID)
			=> BotContext.GetChannelAsync(channelID);

		/// <inheritdoc cref="BotService.CreateChannelAsync(string, CreateChannelReq)"/>
		public Task<Channel> CreateChannelAsync(string guildID, CreateChannelReq channel)
			=> BotContext.CreateChannelAsync(guildID, channel);

		/// <inheritdoc cref="BotService.ModifyChannelAsync(string, ModifyChannelReq)"/>
		public Task<Channel> ModifyChannelAsync(string channelID, ModifyChannelReq channel)
			=> BotContext.ModifyChannelAsync(channelID, channel);
	}
}
