using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TeamManager.Models
{
    public class League
    {
        [Key]
        public int LeagueId {get;set;}

        [Required(ErrorMessage="LeagueName is required")]
        public string Name {get;set;}

        public List<Team> Teams {get;set;}
        //one league has many teams

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdateAt {get;set;} = DateTime.Now;
    }
}