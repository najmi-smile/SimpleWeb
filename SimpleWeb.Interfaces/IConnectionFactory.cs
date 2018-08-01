using System.Data;

namespace SimpleWeb.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection(string connectionString);
    }
}
