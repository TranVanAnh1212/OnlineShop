using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopModel.DAO;
using System.Web;
using System.Web.Mvc;
using OnlineShopModel.EF;
using OnlineShop_v2.Common;
using System.Text;
using System.Globalization;
using System.Threading;

namespace OnlineShop_v2.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        private void SetViewBag(long? selectedID = null)
        {
            var categDAO = new CategoryDAO();
            ViewBag.CategoryID = new SelectList(categDAO.CategoryList(), "ID", "Name", selectedID);
        }        

        // GET: Admin/Content
        public ActionResult Index()
        {
            var contentDAO = new contentDAO();
            var contentList = contentDAO.GetContentAll();
            return View(contentList);
        }

        // GET: Admin/Content/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var contentDAO = new contentDAO();
            var content = contentDAO.GetContentByID(id);
            //content.Detail = HttpUtility.HtmlEncode(content.Detail);
            return View(content);
        }

        // GET: Admin/Content/Create
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        // POST: Admin/Content/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Content content)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var contentDAO = new contentDAO();

                    var session = (UserLogin)Session[CommonConstants.USER_SESSION];

                    if (session != null)
                    {
                        content.CreatedDate = DateTime.Now;
                        content.CreatedBy = session.Username;
                    }

                    string tiengvietKDau = RemoveDiacritics(content.Name);
                    content.MetaTitle = string.Join("-", tiengvietKDau.ToLower().Split(' '));

                    //if (content.Image == null)
                    //{
                    //    content.Image = "/Data/images/default-fallback-image.jpg";
                    //}

                    content.ViewCount = 0;

                    var result = contentDAO.Create(content);

                    if (result)
                    {
                        ModelState.AddModelError("", "Thêm mới thành công.");
                        return RedirectToAction("Index", "Content");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm mới không thành công.");
                    }
                }

                SetViewBag();
                return View();

            }
            catch
            {
                ModelState.AddModelError("", "Có lỗi xảy ra.");
                return View();
            }
        }

        // GET: Admin/Content/Edit/5
        public ActionResult Edit(int id)
        {
            var contentDAO = new contentDAO();
            var content = contentDAO.GetContentByID(id);
            SetViewBag();
            return View(content);
        }

        // POST: Admin/Content/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, Content content)
        {
            try
            {
                // TODO: Add update logic here
                var contentDAO = new contentDAO();

                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                if (session != null)
                {
                    content.ModifiedDate = DateTime.Now;
                    content.ModifiedBy = session.Username;
                }

                string tiengvietKDau = RemoveDiacritics(content.Name);
                content.MetaTitle = string.Join("-", tiengvietKDau.ToLower().Split(' '));

                //if (content.Image == null)
                //{
                //    content.Image = "/Data/images/default-fallback-image.jpg";
                //}

                var result = contentDAO.Update(content);

                if (result)
                {
                    ModelState.AddModelError("", "Cập nhật thành công.");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công.");
                    SetViewBag();
                    return View();
                }
            }
            catch
            {
                SetViewBag();
                return View();
            }
        }

        // GET: Admin/Content/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Content/Delete/5
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
