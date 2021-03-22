using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TeamManager.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required(ErrorMessage="Username is required")]
        [MinLength(6, ErrorMessage="Username must be at least 6 characters")]
        public string Username {get;set;}

        [DataType(DataType.Password)]
        [Required(ErrorMessage="Password is required")]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters long")]
        [Display(Name="Password:")]
        public string Password {get;set;}

        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name="Confirm Password:")]
        [NotMapped]
        public string PassConfirm {get;set;}
        
        public List<Team> Teams {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdateAt {get;set;} = DateTime.Now;
    }
}