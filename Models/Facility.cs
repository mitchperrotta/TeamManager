using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TeamManager.Models
{
    public class Facility
    {
        [Key]
        public int FacilityId {get;set;}

        //type of fcility like training room, board room, player quarters
        public string Type {get;set;}

        //level so that you can upgrade it
        public int Level {get;set;}

        //many to many with teams
        public List<Building> Buildings {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdateAt {get;set;} = DateTime.Now;
    }
}