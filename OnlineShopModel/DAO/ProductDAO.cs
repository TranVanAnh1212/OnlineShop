using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopModel.DAO
{
    public class ProductDAO
    {
        public List<Product> ProductListAll()
        {
            return DataProvider.Instance.DB.Product.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public List<Product> ProductListPage(ref int totalRecord,string searchQuery, int pageIndex = 1, int pageSize = 12)
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                totalRecord = DataProvider.Instance.DB.Product.Where(x => x.Name.Contains(searchQuery)).Count();
                return DataProvider.Instance.DB.Product.Where(x => x.Name.Contains(searchQuery)).OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }

            totalRecord = DataProvider.Instance.DB.Product.Where(x => x.Status == true).Count();
            return DataProvider.Instance.DB.Product.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<String> ListNameProduct(string key)
        {
            return DataProvider.Instance.DB.Product.Where(x => x.Name.Contains(key) && x.Status == true).Select(x => x.Name).ToList();
        }

        public List<Product> ProductListIsHidden()
        {
            return DataProvider.Instance.DB.Product.Where(x => x.Status == false).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public List<Product> NewProductList()
        {
            return DataProvider.Instance.DB.Product.Where(x => x.Status == true).OrderBy(x => x.CreatedDate).Take(4).ToList();
        }

        public List<Product> PCViewDetail(long categID)
        {
            return DataProvider.Instance.DB.Product.Where(x => x.Status == true && x.CategoryID == categID).OrderBy(x => x.BoughtCount).ToList();
        }

        public List<Product> SearchProduct(string searchQuery, ref int totalRecorder, int pageIndex = 1, int pageSize = 12)
        {
            totalRecorder = DataProvider.Instance.DB.Product.Where(x => x.Status == true && x.Name.Contains(searchQuery)).Count();
            return DataProvider.Instance.DB.Product.Where(x => x.Status == true && x.Name.Contains(searchQuery)).OrderBy(x => x.BoughtCount).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Product> getListByCategID(long categID, ref int totalRecord, int pageIndex = 1, int PageSize = 12)
        {
            totalRecord = DataProvider.Instance.DB.Product.Where(x => x.Status == true && x.CategoryID == categID).Count();
            return DataProvider.Instance.DB.Product.Where(x => x.Status == true && x.CategoryID == categID).OrderBy(x => x.BoughtCount).Skip((pageIndex - 1) * PageSize).Take(PageSize).ToList();
        }

        public List<Product> FeatureProductList()
        {
            return DataProvider.Instance.DB.Product.Where(x => x.Status == true).OrderBy(x => x.BoughtCount).Take(4).ToList();
        }

        public List<Product> RelatedProduct(long id)
        {
            var product = DataProvider.Instance.DB.Product.Find(id);
            return DataProvider.Instance.DB.Product.Where(x => x.ID != id && x.CategoryID == product.CategoryID).ToList();
        }

        public bool Create(Product product)
        {
            if (product != null)
            {
                DataProvider.Instance.DB.Product.Add(product);
                DataProvider.Instance.DB.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public Product GetProductByID(long id)
        {
            return DataProvider.Instance.DB.Product.Where(x => x.ID == id).FirstOrDefault();
        }

        public bool Delete (Product product)
        {
            var productRes = DataProvider.Instance.DB.Product.Where(x => x.ID == product.ID).FirstOrDefault();
            if (productRes != null)
            {
                DataProvider.Instance.DB.Product.Remove(productRes);
                DataProvider.Instance.DB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update (Product product)
        {
            var productRes = DataProvider.Instance.DB.Product.Where(x => x.ID == product.ID).FirstOrDefault();

            if (productRes != null)
            {
                productRes.Name = product.Name;
                productRes.MetaTitle = product.MetaTitle;
                productRes.Price = product.Price;
                productRes.PromotionPrice = product.PromotionPrice;
                productRes.CategoryID = product.CategoryID;
                productRes.Quanlity = product.Quanlity;
                productRes.Detail = product.Detail;
                productRes.Description = product.Description;
                productRes.Image = product.Image;
                productRes.ModifiedBy = product.ModifiedBy;
                productRes.ModifiedDate = product.ModifiedDate;
                productRes.MetaDescription = product.MetaDescription;
                productRes.MetaKeywords = product.MetaKeywords;
                productRes.Status = product.Status;
                productRes.TopHot = product.TopHot;
                productRes.Warranty = product.Warranty;

                DataProvider.Instance.DB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
