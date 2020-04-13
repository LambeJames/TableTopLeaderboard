using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TableTopLeaderboard.Models
{
    public class PlayerModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }
    }
}