using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TropicalServerApp.Models
{
    public class UserAccount
    {
        [Required(ErrorMessage ="Please Enter your UserID")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Please Enter your Password")]
        public string Password { get; set; }

        public string EmailID { get; set; }
    }
}