using OnlineShopModel.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_v2.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()        
        {
            var productCateg = new ProductCategoryDAO().ListProductCateg();
            return View(productCateg);
        }        
    }
}