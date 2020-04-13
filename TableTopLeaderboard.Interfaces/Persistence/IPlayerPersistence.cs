using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTopLeaderboard.Models;

namespace TableTopLeaderboard.Interfaces.Persistence
{
    public interface IPlayerPersistence
    {
        Task<IEnumerable<Player>> GetAll();
        Task<bool> Add(Player model);
        Task<bool> Update(Player model);
        Task<bool> Delete(int id);
    }
}
