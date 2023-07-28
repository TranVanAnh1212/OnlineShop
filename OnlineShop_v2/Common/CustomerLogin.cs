using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop_v2.Common
{
    public class CustomerLogin
    {
        public long UserID { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string AvatarURL { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
    }
}