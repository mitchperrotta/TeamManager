using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TeamManager.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage="Username is required")]
        [Display(Name="Username:")]
        public string LoginUsername{get;set;}
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage="Password is required")]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters long")]
        [Display(Name="Password:")]
        public string LoginPassword{get;set;}
    }
}