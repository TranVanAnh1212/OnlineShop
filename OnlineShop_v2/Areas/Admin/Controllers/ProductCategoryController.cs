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
    public class ProductCategoryController : BaseController
    {
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            var productCateg = new ProductCategoryDAO().ListProductCateg();
            return View(productCateg);
        }

        // GET: Admin/ProductCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ProductCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductCategory/Create
        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var productCategDAO = new ProductCategoryDAO();

                    var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                    var sessionCalture = Session[CommonConstants.CurrentCulture];
                    productCategory.Language = sessionCalture.ToString();

                    if (session != null)
                    {
                        productCategory.CreatedBy = session.Username;
                        productCategory.CreatedDate = DateTime.Now;
                    }

                    productCategory.MetaTitle = string.Join("-", RemoveDiacritics(productCategory.Name).ToLower().Split(' '));

                    if (productCategDAO.Create(productCategory))
                    {
                        SetAlert("Thêm mới danh mục sản phẩm thành công.", "Success");
                        return RedirectToAction("Index", "ProductCategory");
                    }else
                    {
                        ModelState.AddModelError("", "Thêm mới danh mục sản phẩm thất bại.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới danh mục sản phẩm thất bại.");
                }

                return View();
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới danh mục sản phẩm thất bại.");
                return View();
            }
        }

        // GET: Admin/ProductCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/ProductCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ProductCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ProductCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
