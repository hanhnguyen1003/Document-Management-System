using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { set; get; }
        public string PassWord { set; get; }
      
    }
}