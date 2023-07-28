using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopModel.DAO
{
    public class CategoryDAO
    {
        public List<Category> CategoryList()
        {
            return DataProvider.Instance.DB.Category.Where(x => x.Status == true).ToList();
        }
    }
}
