using System.Collections.Immutable;
using Rg.Web.Api.Models;
using Rg.Web.Api.Repository;

namespace Rg.Web.Api.Services;

public interface IChatService
{
    public Task<ImmutableList<Chat>> GetChats();
    public Task<ImmutableList<Message>> GetMessages(long chatId, int count);
    public Task<long> WriteMessage(MessageWriteDto message);
}