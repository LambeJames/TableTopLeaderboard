using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TableTopLeaderboard.Interfaces.Persistence.Handles
{
    public interface ISqlHandle
    {
        Task<SqlConnection> CreateConnection();
    }
}
