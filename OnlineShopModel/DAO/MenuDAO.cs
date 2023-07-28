using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopModel.DAO
{
    public class MenuDAO
    {
        public List<Menu> ListMenu(long id)
        {
            return DataProvider.Instance.DB.Menu.Where(x => x.TypeID == id && x.Status == true).OrderBy(x => x.ID).ToList();
        }

        public Menu GetmenuItem(string name)
        {
            return DataProvider.Instance.DB.Menu.Where(x => x.TypeID == 2 && x.Text == name).FirstOrDefault();
        }

        public void UpdateTopMenuStatus(Menu menu)
        {
            var menuItem = DataProvider.Instance.DB.Menu.Where(x => x.TypeID == 2 && x.ID == menu.ID).FirstOrDefault();
            menuItem.Status = menu.Status;
            DataProvider.Instance.DB.SaveChanges();
        }
    }
}
