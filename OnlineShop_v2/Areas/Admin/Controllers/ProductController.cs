using OnlineShop_v2.Common;
using OnlineShopModel.DAO;
using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_v2.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private void SetViewBag(long? id = null)
        {
            var productCategoryDAO = new ProductCategoryDAO();
            ViewBag.CategoryID = new SelectList(productCategoryDAO.ListProductCateg(), "ID", "Name", id);
        }

        // GET: Admin/Product
        public ActionResult Index(string searchQuery, int page = 1, int pageSize = 12 )
        {
            searchQuery = Request.QueryString["searchQuery"];
            ViewBag.searchQuery = searchQuery;

            int totalRecord = 0;

            var productDao = new ProductDAO();
            var product = productDao.ProductListPage(ref totalRecord, searchQuery, page, pageSize);

            ViewBag.totalRecord = totalRecord;
            ViewBag.PageIndex = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling(((Double)totalRecord / (Double)pageSize));

            ViewBag.totalPage = totalPage;
            ViewBag.maxPage = maxPage;
            ViewBag.firstPage = 1;
            ViewBag.lastPage = totalPage;
            ViewBag.nextPage = page + 1;
            ViewBag.PrevPage = page - 1;

            return View(product);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            var product = new ProductDAO().GetProductByID(id);
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        //POST: Admin/Product/Create
       [HttpPost, ValidateInput(false)]
       [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var productDAO = new ProductDAO();
                    var session = (UserLogin)Session[CommonConstants.USER_SESSION];

                    if (session != null)
                    {
                        product.CreatedDate = DateTime.Now;
                        product.CreatedBy = session.Username;
                    }

                    string tiengvietKDau = RemoveDiacritics(product.Name);
                    product.MetaTitle = string.Join("-", tiengvietKDau.ToLower().Split(' '));

                    product.ViewCount = 0;

                    string prodDescEncode = HttpUtility.HtmlEncode(product.Description);
                    product.Description = prodDescEncode;

                    string prodDetailEncode = HttpUtility.HtmlEncode(product.Detail);
                    product.Detail = prodDetailEncode;

                    var result = productDAO.Create(product);

                    if (result)
                    {
                        SetAlert("Thêm mới sản phẩm Thành công.", "Success");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        SetAlert("Thêm mới sản phẩm thất bại.", "Error");
                        ModelState.AddModelError("", "Thêm mới sản phẩm thất bại.");
                    }
                }

                SetViewBag();
                ModelState.AddModelError("", "Có lỗi trong khi thêm sản phẩm mới.");
                return View();
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới sản phẩm thất bại.");
                return View();
            }
        }

        //[HttpPost]        
        //public JsonResult CreateProduct(string name)
        //{
        //    return Json(new
        //    {
        //        status = true
        //    });
        //}

        // GET: Admin/Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = new ProductDAO().GetProductByID(id);
            SetViewBag();
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                // TODO: Add update logic here
                var productDAO = new ProductDAO();
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];

                if (session != null)
                {
                    product.ModifiedBy = session.Username;
                    product.ModifiedDate = DateTime.Now;
                }

                var result = productDAO.Update(product);
                if (result)
                {
                    SetAlert("Cập nhật sản phẩm thành công", "Success");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sản phẩm thất bại");
                    return View();
                }
            }
            catch
            {
                SetViewBag();
                return View();
            }
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = new ProductDAO().GetProductByID(id);
            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                // TODO: Add delete logic here
                var productDAO = new ProductDAO();

                if (productDAO.Delete(product))
                {
                    SetAlert("Xóa sản phẩ thành công.", "Success");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Xóa sản phẩm thất bại.");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
