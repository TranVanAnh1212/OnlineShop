using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop_v2.Models
{
    [Serializable]
    public class CartItem
    {
        public Product product { get; set; }
        public long UserID { get; set; }
        public int Quanlity { get; set; }

    }
}