using System.Data;

namespace Rg.Db;

public interface IDbContext
{
    /// <summary>
    /// Текущее подключение к БД
    /// </summary>
    IDbConnection Connection { get; }
}