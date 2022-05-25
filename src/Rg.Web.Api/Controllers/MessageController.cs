using System.Collections.Immutable;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Rg.Web.Api.Attributes;
using Rg.Web.Api.Hubs;
using Rg.Web.Api.Models;
using Rg.Web.Api.Repository;
using Rg.Web.Api.Services;

namespace Rg.Web.Api.Controllers;

[ApiController]
[Route("api/message")]
[Authorize]
[Consumes("application/json")]
[Produces("application/json")]
public class MessageController : ControllerBase
{
    private readonly IHubContext<ChatHub, IChatHub> _hubContext;

    /// <inheritdoc />
    public MessageController(IHubContext<ChatHub, IChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task<ActionResult<ImmutableList<Message>>> GetLastMessages(
        [FromQuery] long chatId,
        [DefaultValue(50)] [FromQuery] int count,
        [FromServices] IChatService chatService
    )
    {
        return await chatService.GetMessages(chatId, count);
    }

    [HttpPost]
    public async Task<ActionResult<long>> SendMessage(MessageWriteDto message, [FromServices] IChatService chatService)
    {
        var id = await chatService.WriteMessage(message);
        await _hubContext.Clients.Group(message.ChatId.ToString()).NewMessage(new Message(
            id,
            message.ChatId,
            message.UserId,
            message.Text,
            message.Dt));
        return id;
    }
}