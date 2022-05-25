using System.Collections.Immutable;
using Dapper;
using Rg.Db;
using Rg.Web.Api.Models;

namespace Rg.Web.Api.Repository;

public class ChatRepository : IChatRepository
{
    private readonly IDbContext _dbContext;

    public ChatRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<ImmutableList<Chat>> GetChats()
    {
        const string query = @"
select
        id,
        name,
        clan_id
    from public.chat;
";

        var chats = await _dbContext.Connection.QueryAsync<Chat>(query);
        return chats.ToImmutableList();
    }
}