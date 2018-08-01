using System.Data.SqlClient;
using SimpleWeb.Interfaces;
using System.Data;

namespace SimpleWeb.Services.Helpers
{
    internal class SqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
