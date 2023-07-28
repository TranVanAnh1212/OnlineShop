using OnlineShop_v2.Models;
using OnlineShopModel.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_v2.Controllers
{
    public class BaseClientController : Controller
    {
        // GET: BaseClient
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult _MainMenu()
        {
            var menu = new MenuDAO().ListMenu(1);
            return PartialView(menu);
        }

        [ChildActionOnly]
        public ActionResult _TopMenu()
        {
            var menu = new MenuDAO().ListMenu(2);
            return PartialView(menu);
        }

        [HttpGet]
        public ActionResult _HeaderTop()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        public List<CartItem> GetListCart()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return list;
        }
    }
}