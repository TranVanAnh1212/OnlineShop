using OnlineShopModel.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_v2.Controllers
{
    public class ClientProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(long categID, int page = 1, int pageSize = 1)
        {
            var listProduct = new ProductDAO().PCViewDetail(categID);
            ViewBag.ProductCateg = new ProductCategoryDAO().ProductCateg(categID);

            int totalRecorder = 0;
            var model = new ProductDAO().getListByCategID(categID,ref totalRecorder, page, pageSize);

            ViewBag.total = totalRecorder;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling(((Double)totalRecorder / (Double)pageSize));

            ViewBag.totalPage = totalPage;
            ViewBag.maxPage = maxPage;
            ViewBag.firstPage = 1;
            ViewBag.lastPage = totalPage;
            ViewBag.nextPage = page + 1;
            ViewBag.PrevPage = page - 1;

            return View(model);
        }

        public ActionResult ViewProductDetail(long prodID)
        {
            var product = new ProductDAO().GetProductByID(prodID);
            ViewBag.ProductCategoryList = new ProductCategoryDAO().ListProductCateg();
            ViewBag.RelatedProduct = new ProductDAO().RelatedProduct(prodID);
            return View(product);
        }

        public JsonResult ListNameProduct(string term)
        {
            var result = new ProductDAO().ListNameProduct(term);

            return Json(new
            {
                data = result,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string searchQuery, int page = 1, int pageSize = 12)
        {
            ViewBag.keywword = searchQuery;

            int totalRecorder = 0;
            var model = new ProductDAO().SearchProduct(searchQuery, ref totalRecorder, page, pageSize);

            ViewBag.total = totalRecorder;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling(((Double)totalRecorder / (Double)pageSize));

            ViewBag.totalPage = totalPage;
            ViewBag.maxPage = maxPage;
            ViewBag.firstPage = 1;
            ViewBag.lastPage = totalPage;
            ViewBag.nextPage = page + 1;
            ViewBag.PrevPage = page - 1;

            return View(model);
        }

    }
}