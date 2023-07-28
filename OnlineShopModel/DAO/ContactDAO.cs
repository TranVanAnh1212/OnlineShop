using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopModel.EF;

namespace OnlineShopModel.DAO
{
    public class ContactDAO
    {
        public Contacts GetContact()
        {
            return DataProvider.Instance.DB.Contacts.Where(x => x.Status == true).FirstOrDefault();
        }
    }
}
