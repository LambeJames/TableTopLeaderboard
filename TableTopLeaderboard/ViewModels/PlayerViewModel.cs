using System.ComponentModel.DataAnnotations;

namespace TableTopLeaderboard.ViewModels
{
    public class PlayerViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }
    }
}