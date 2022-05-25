using System.Collections.Immutable;
using Dapper;
using Rg.Db;
using Rg.Web.Api.Models;

namespace Rg.Web.Api.Repository;

public class UserRepository : IUserRepository
{
    private readonly IDbContext _dbContext;

    public UserRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<ImmutableList<User>> GetUsers()
    {
        const string query = @"
select
        id,
        login,
        password,
        clan_id
    from ""user""";

        var users = await _dbContext.Connection.QueryAsync<User>(query);
        return users.ToImmutableList();
    }
}