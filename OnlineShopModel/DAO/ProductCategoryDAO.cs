using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopModel.DAO
{
    public class ProductCategoryDAO
    {
        public List<ProductCategory> ListProductCateg()
        {
            return DataProvider.Instance.DB.ProductCategory.Where(x => x.Status == true).ToList();
        }

        public bool Create(ProductCategory productCategory)
        {
            if (productCategory != null)
            {
                DataProvider.Instance.DB.ProductCategory.Add(productCategory);
                DataProvider.Instance.DB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public ProductCategory ProductCateg (long ID)
        {
            return DataProvider.Instance.DB.ProductCategory.Where(x => x.ID == ID).FirstOrDefault();
        }
    }
}
