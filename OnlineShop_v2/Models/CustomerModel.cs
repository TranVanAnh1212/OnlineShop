using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop_v2.Models
{
    public class CustomerModel
    {
        [Key]
        public long ID { get; set; }

        [StringLength(150, ErrorMessage = "Tên đăng nhập quá dài")]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Trường này là bắt buộc")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [StringLength( 64, MinimumLength = 8, ErrorMessage = "Mật khẩu tối thiểu 8 ký tự")]
        [Required(ErrorMessage = "Trường này là bắt buộc")]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string ConfirmedPassword { get; set; }
    }
}