using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TableTopLeaderboard.Interfaces.Persistence;
using TableTopLeaderboard.Interfaces.Persistence.Handles;
using TableTopLeaderboard.Models;

namespace TableTopLeaderboard.Persistence
{
    public class PlayerPersistence : IPlayerPersistence
    {
        private readonly ISqlHandle _sqlHandle;

        public PlayerPersistence(ISqlHandle sqlHandle)
        {
            _sqlHandle = sqlHandle;
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            using (var dbConnection = await _sqlHandle.CreateConnection())
            {
                var players = await dbConnection.QueryAsync<Player>(
                    sql: "GetPlayers",
                    commandType: CommandType.StoredProcedure);

                return players;
            }
        }

        public async Task<bool> Add(Player model)
        {
            using (var dbConnection = await _sqlHandle.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", model.FirstName);
                parameters.Add("@LastName", model.LastName);

                var affectedRows = await dbConnection.ExecuteAsync(
                    sql: "AddNewPlayer",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                return affectedRows >= 1;
            }
        }

        public async Task<bool> Update(Player model)
        {
            using (var dbConnection = await _sqlHandle.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", model.Id);
                parameters.Add("@FirstName", model.FirstName);
                parameters.Add("@LastName", model.LastName);

                var affectedRows = await dbConnection.ExecuteAsync(
                    sql: "UpdateStudentDetails",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                return affectedRows >= 1;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var dbConnection = await _sqlHandle.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var affectedRows = await dbConnection.ExecuteAsync(
                    sql: "DeletePlayer",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                return affectedRows >= 1;
            }
        }
    }
}
