using System.Collections.Immutable;
using Rg.Web.Api.Models;
using Rg.Web.Api.Repository;

namespace Rg.Web.Api.Services;

public class ChatService : IChatService
{
    private readonly IUserRepository _userRepository;
    private readonly IChatRepository _chatRepository;
    private readonly IMessageRepository _messageRepository;
    private readonly IIdentityService _identityService;

    public ChatService(IUserRepository userRepository, IChatRepository chatRepository,
        IMessageRepository messageRepository, IIdentityService identityService)
    {
        _userRepository = userRepository;
        _chatRepository = chatRepository;
        _messageRepository = messageRepository;
        _identityService = identityService;
    }

    /// <inheritdoc />
    public async Task<ImmutableList<Chat>> GetChats()
    {
        var chats = await _chatRepository.GetChats();
        return chats;
    }

    /// <inheritdoc />
    public async Task<ImmutableList<Message>> GetMessages(long chatId, int count)
    {
        var userId = await _identityService.UserId;
        if (await IsUserMemberOfChat(userId, chatId))
        {
            return await _messageRepository.GetLastMessages(chatId, count);
        }

        throw new ChatException("Пользователь не является участником клана");
    }

    /// <inheritdoc />
    public async Task<long> WriteMessage(MessageWriteDto message)
    {
        if (await IsUserMemberOfChat(message.UserId, message.ChatId))
        {
            return await _messageRepository.SendMessage(message);
        }

        throw new ChatException("Пользователь не является участником клана");
    }

    private async Task<bool> IsUserMemberOfChat(long? userId, long chatId)
    {
        var users = await _userRepository.GetUsers();
        var user = users.FirstOrDefault(x => x.Id == userId);
        var chats = await _chatRepository.GetChats();
        var chat = chats.FirstOrDefault(x => x.Id == chatId);
        return chat?.ClanId == user?.ClanId;
    }
}

public class ChatException : Exception
{
    public ChatException(string message) : base(message)
    {
    }

    public ChatException(string message, Exception innerException) : base(message, innerException)
    {
    }
}