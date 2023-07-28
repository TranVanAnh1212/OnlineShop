using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop_v2.Areas.Admin.Data
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Trường này không được bỏ trống")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Trường này không được bỏ trống")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}