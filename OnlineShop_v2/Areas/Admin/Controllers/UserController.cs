using OnlineShop_v2.Common;
using OnlineShopModel.DAO;
using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_v2.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {

        // GET: Admin/User
        public ActionResult Index(string searchQuery, int page = 1, int pageSize = 10)
        {
            // Lấy lên searchQuery từ Form của index.cshtml
            searchQuery = Request.QueryString["searchQuery"];

            var userDAO = new UserDAO();
            var userList = userDAO.UserList(searchQuery, page, pageSize);

            ViewBag.searchQuery = searchQuery;

            return View(userList);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int id)
        {
            var userDAO = new UserDAO().GetUserByID(id);

            return View(userDAO);
        }

        // GET: Admin/User/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var userDAO = new UserDAO();
                    var session = (UserLogin) Session[CommonConstants.USER_SESSION];

                    user.Password = Enscryptor.MD5Hash(user.Password);

                    user.CreatedDate = DateTime.Now;

                    if (session != null)
                    {
                        user.CreatedBy = session.Username;
                    }

                    var id = userDAO.Insert(user);

                    if (id > 0)
                    {
                        SetAlert("Thêm mới user thành công", "Success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        SetAlert("Thêm mới user không thành công", "Error");
                        ModelState.AddModelError("", "Thêm user mới thất bại.");
                    }

                }
                return View();
            }
            catch
            {
                ModelState.AddModelError("", "Có lỗi xảy ra.");
                return View();
            }
        }

        // GET: Admin/User/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userDAO = new UserDAO().GetUserByID(id);
            return View(userDAO);
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                var userDAO = new UserDAO();
                var pass = userDAO.GetUserByID(id).Password;

                if (user.Password != pass)
                {
                    var enscryptPass = Enscryptor.MD5Hash(user.Password);
                    user.Password = enscryptPass;
                }

                var session = (UserLogin)Session[CommonConstants.USER_SESSION];

                if (session != null)
                {
                    user.ModifiedBy = session.Username;
                }

                var result = userDAO.Update(user);

                if (result)
                {
                    SetAlert("Sửa user thành công", "Success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Sửa user không thành công", "Error");
                }

                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Có lỗi xảy ra.");
                return View();
            }
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int id)
        {
            var userDAO = new UserDAO().GetUserByID(id);
            return View(userDAO);
        }

        // POST: Admin/User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                // TODO: Add delete logic here
                new UserDAO().Delete(user);
                SetAlert("Xóa user thành công", "Success");
                return RedirectToAction("Index");
            }
            catch
            {
                SetAlert("Xóa user không thành công", "Error");
                ModelState.AddModelError("", "Có lỗi xảy ra.");
                return View();
            }
        }

        [HttpPost]
        public JsonResult ChangedStatus(long id)
        {
            var result = new UserDAO().ChangedStatus(id);

            return Json(new
            {
                status = result
            });
        }
    }
}
