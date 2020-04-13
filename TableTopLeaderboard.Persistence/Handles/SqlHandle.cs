using System.Data.SqlClient;
using System.Threading.Tasks;
using TableTopLeaderboard.Interfaces.Persistence.Handles;

namespace TableTopLeaderboard.Persistence.Handles
{
    public class SqlHandle : ISqlHandle
    {
        private readonly string _connectionString;

        public SqlHandle(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<SqlConnection> CreateConnection()
        {
            var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            return conn;
        }
    }
}
