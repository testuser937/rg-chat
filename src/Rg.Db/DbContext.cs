using System.Data;
using Dapper;
using Npgsql;

namespace Rg.Db;

public class DbContext
    : IDbContext, IDisposable
{
    private readonly DbConfiguration _dbConfiguration;

    /// <summary>
    /// Текущее подключение к БД
    /// </summary>
    public IDbConnection Connection { get; protected set; }

    public DbContext(DbConfiguration dbConfiguration)
    {
        _dbConfiguration = dbConfiguration;

        DefaultTypeMap.MatchNamesWithUnderscores = true;

        Connect();
    }

    private void Connect()
    {
        Connection = new NpgsqlConnection(_dbConfiguration.ConnectionString);
        Connection.Open();
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Connection.Dispose();
    }
}