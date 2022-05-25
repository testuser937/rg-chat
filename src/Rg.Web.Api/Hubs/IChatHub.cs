using Rg.Web.Api.Models;
using Rg.Web.Api.Repository;

namespace Rg.Web.Api.Hubs;

public interface IChatHub
{
    Task JoinChat(long chatId);

    Task LeaveChat(long chatId);

    Task NewMessage(Message message);
}