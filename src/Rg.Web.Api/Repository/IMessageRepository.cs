using System.Collections.Immutable;
using Rg.Web.Api.Models;

namespace Rg.Web.Api.Repository;

public interface IMessageRepository
{
    Task<ImmutableList<Message>> GetLastMessages(long chatId, int count = 50);

    Task<long> SendMessage(MessageWriteDto message);
}