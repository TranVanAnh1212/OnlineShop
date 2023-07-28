using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopModel.DAO
{
    public class OrderDAO
    {
        public long Insert(Order order)
        {
            DataProvider.Instance.DB.Order.Add(order);
            DataProvider.Instance.DB.SaveChanges();
            return order.ID;
        }

        public List<Order> GetOrderAll()
        {
            return DataProvider.Instance.DB.Order.ToList();
        }
    }
}
