using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TeamManager.Models
{
    public class Staff
    {
        [Key]
        public int StaffId {get;set;}

        public string Name {get;set;}

        //head coach/position coach/PR/talent scout
        public string Role {get;set;}

        //stats
        public int GameKnowledge {get;set;}
        public int Communication {get;set;}
        public int Charisma {get;set;}
        public int BuisnessKnowledge {get;set;}

        //salary upkeep
        public int Salary {get;set;}

        //contract length if picked up
        public DateTime ContractLength {get;set;}

        //many staff to one team
        public int TeamId {get;set;}
        public Team ContractedTo {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdateAt {get;set;} = DateTime.Now;
    }
}