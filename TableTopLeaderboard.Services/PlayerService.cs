using System.Collections.Generic;
using System.Threading.Tasks;
using TableTopLeaderboard.Interfaces.Persistence;
using TableTopLeaderboard.Interfaces.Services;
using TableTopLeaderboard.Models;

namespace TableTopLeaderboard.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerPersistence _playerPersistence;

        public PlayerService(IPlayerPersistence playerPersistence)
        {
            _playerPersistence = playerPersistence;
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await _playerPersistence.GetAll();
        }

        public async Task<bool> Add(Player model)
        {
            return await _playerPersistence.Add(model);
        }

        public async Task<bool> Update(Player model)
        {
            return await _playerPersistence.Update(model);
        }

        public async Task<bool> Delete(int id)
        {
            return await _playerPersistence.Delete(id);
        }
    }
}
