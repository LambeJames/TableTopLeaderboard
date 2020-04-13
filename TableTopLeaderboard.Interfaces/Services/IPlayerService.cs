using System.Collections.Generic;
using System.Threading.Tasks;
using TableTopLeaderboard.Models;

namespace TableTopLeaderboard.Interfaces.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetAll();

        Task<bool> Add(Player model);

        Task<bool> Update(Player model);

        Task<bool> Delete(int id);
    }
}
