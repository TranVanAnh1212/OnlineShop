using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopModel.DAO
{
    public class FeedbackDAO
    {
        public long Insert(Feedback feedback)
        {
            DataProvider.Instance.DB.Feedback.Add(feedback);
            DataProvider.Instance.DB.SaveChanges();
            return feedback.ID;
        }
    }
}
