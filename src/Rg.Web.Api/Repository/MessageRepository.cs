using System.Collections.Immutable;
using Dapper;
using Rg.Db;
using Rg.Web.Api.Models;

namespace Rg.Web.Api.Repository;

public class MessageRepository : IMessageRepository
{
    private readonly IDbContext _dbContext;

    public MessageRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<ImmutableList<Message>> GetLastMessages(long chatId, int count = 50)
    {
        const string query = @"
select
        id,
        chat_id,
        user_id,
        text,
        dt
    from message
    where chat_id = :chatId
    order by dt desc
    limit :count;
";
        var messages = await _dbContext.Connection.QueryAsync<Message>(query, new { chatId, count });
        return messages.OrderBy(x => x.Dt).ToImmutableList();
    }

    /// <inheritdoc />
    public async Task<long> SendMessage(MessageWriteDto message)
    {
        const string query = @"
insert into message
(
    chat_id,
    user_id,
    text,
    dt
)
values
(
    :chatId,
    :userId,
    :text,
    :dt
)
returning id
";
        var id = await _dbContext.Connection.ExecuteScalarAsync<long>(query, message);
        return id;
    }
}