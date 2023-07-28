using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopModel.DAO
{
    public class contentDAO
    {
        public List<Content> GetContentAll()
        {
            return DataProvider.Instance.DB.Content.ToList();
        }

        public Content GetContentByID(long id)
        {
            return DataProvider.Instance.DB.Content.Where(x => x.ID == id).FirstOrDefault();
        }

        public bool Create(Content content)
        {
            if (content != null)
            {
                DataProvider.Instance.DB.Content.Add(content);
                DataProvider.Instance.DB.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Content content)
        {
            if (content != null)
            {
                var cont = DataProvider.Instance.DB.Content.Where(x => x.ID == content.ID).FirstOrDefault();

                if (cont != null)
                {
                    cont.Name = content.Name;
                    cont.MetaTitle = content.MetaTitle;
                    cont.Description = content.Description;
                    cont.Image = content.Image;
                    cont.CategoryID = content.CategoryID;
                    cont.Detail = content.Detail;
                    cont.ModifiedBy = content.ModifiedBy;
                    cont.ModifiedDate = content.ModifiedDate;
                    cont.MoreImage = content.MoreImage;
                    cont.Status = content.Status;
                    content.Warranty = content.Warranty;
                    cont.MetaDescription = content.MetaDescription;
                    cont.MetaKeywords = content.MetaKeywords;

                    DataProvider.Instance.DB.SaveChanges();
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
