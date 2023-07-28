using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop_v2.Models
{
    public class CustomerLoginVM
    {
        [Key]
        public long ID { get; set; }

        [Required(ErrorMessage = "Trường này là bắt buộc")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Trường này là bắt buộc")]
        public string Password { get; set; }
    }
}