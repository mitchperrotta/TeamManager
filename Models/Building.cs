using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TeamManager.Models
{
    public class Building
    {
        [Key]
        public int BuildingId {get;set;}

        //many teams to many facilities
        public int TeamId {get;set;}
        public int FacilityId {get;set;}
        public Team OwnedBy {get;set;}
        public Facility BuildingType {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdateAt {get;set;} = DateTime.Now;
    }
}