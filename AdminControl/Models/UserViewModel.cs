using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;
using System.ComponentModel.DataAnnotations;

namespace AdminControl.Models
{
    public class UserViewModel
    {
        public UserViewModel() { }

        public string userId { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        public string phoneNumber { get; set; }
        public string address { get; set; }

        [Required]
        public string gender { get; set; }
        public DateTime birthday { get; set; }
        public string role { get; set; }
    }

    public class LoginViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public bool rememberMe { get; set; }
    }

    public class CheckViewModel
    {
        public string checkLogin { get; set; }
        public string role { get; set; }
    }

    public class Role
    {
        public string role { get; set; }
    }

}