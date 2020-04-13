using TableTopLeaderboard.Models;
using TableTopLeaderboard.ViewModels;

namespace TableTopLeaderboard.ViewModelBuilders
{
    public static class PlayerViewModelMapper
    {
        public static PlayerViewModel ToViewModel(this Player model)
        {
            return new PlayerViewModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }

        public static Player ToModel(this PlayerViewModel viewModel)
        {
            return new Player
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName
            };
        }
    }
}