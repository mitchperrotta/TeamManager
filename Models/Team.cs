using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TeamManager.Models
{
    public class Team
    {
        [Key]
        public int TeamId {get;set;}

        [Required(ErrorMessage="Team name is required")]
        [MinLength(2, ErrorMessage="Team name must be at least 2 characters")]
        public string Name {get;set;}

        [Required(ErrorMessage="Team logo is required")]
        public string Logo {get;set;}

        //weekly income
        public int Income {get;set;}

        //upkeep cost
        public int Upkeep {get;set;}

        //available cash
        public int Cash {get;set;}

        public int UserId {get;set;}
        public User Owner {get;set;}
        //many teams can have one user

        public int LeagueId {get;set;}
        public League JoinedLeague {get;set;}
        //many teams can have one league

        public List<Player> TeamPlayers {get;set;}
        //one team can have many players

        public List<Staff> TeamStaff {get;set;}
        //one team can have many staff

        public List<Building> Buildings {get;set;}
        //many teams can have many facilities

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdateAt {get;set;} = DateTime.Now;

        //add constructor form to make default values
    }
}