using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopModel.DAO
{
    public class CustomerDAO
    {
        public long Insert(Customer cus)
        {
            DataProvider.Instance.DB.Customer.Add(cus);
            DataProvider.Instance.DB.SaveChanges();
            return cus.ID;
        }

        public long InsertCusFB(Customer cus)
        {
            var cust = DataProvider.Instance.DB.Customer.Where(x => x.Username == cus.Username).SingleOrDefault();

            if (cust == null)
            {
                DataProvider.Instance.DB.Customer.Add(cus);
                DataProvider.Instance.DB.SaveChanges();
            }
            
            return cust.ID;
        }

        public bool GetUserByUserName(string userName, string password)
        {
            return DataProvider.Instance.DB.Customer.Where(x => x.status == true).Count(x => x.Username == userName && x.Password == password) > 0;
        }

        public bool CheckUserName(string userName)
        {
            return DataProvider.Instance.DB.Customer.Count(x => x.Username == userName) > 0;
        }
    }
}
