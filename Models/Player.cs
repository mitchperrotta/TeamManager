using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TeamManager.Models
{
    public class Player
    {
        [Key]
        public int PlayerId {get;set;}

        [Required]
        public string UserName {get;set;}

        [Required]
        public string RealName {get;set;}

        public string Position {get;set;}

        //player stats
        public int Knowledge {get;set;}
        public int Leadership {get;set;}
        public int Aggresion {get;set;}
        public int LastHitting {get;set;}
        public int TeamFighting {get;set;}
        public int Laning {get;set;}
        public int Mental {get;set;}

        //salary upkeep
        public int Salary {get;set;}

        //contract length if picked up
        public DateTime ContractLength {get;set;}

        //many players to one team
        public int TeamId {get;set;}
        public Team ContractedTo {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdateAt {get;set;} = DateTime.Now;
    }
}