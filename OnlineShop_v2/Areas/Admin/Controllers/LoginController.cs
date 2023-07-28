using OnlineShop_v2.Areas.Admin.Data;
using OnlineShop_v2.Common;
using OnlineShopModel.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_v2.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel loginM)
        {
            if (ModelState.IsValid)
            {
                var loginDAO = new UserDAO();
                var res = loginDAO.Login(loginM.Username, Enscryptor.MD5Hash(loginM.Password));

                if (res == 1)
                {
                    var user = loginDAO.GetUserByID(loginM.Username);
                    var userSession = new UserLogin();

                    userSession.Username = user.Username;
                    userSession.UserID = user.ID;
                    userSession.AvatarURL = user.avatarUrl;
                    userSession.Address = user.Address;
                    userSession.DisplayName = user.DisplayName;
                    userSession.Phone = user.Phone;
                    userSession.Email = user.Email;
                    userSession.Birthday = user.Birthday;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "AdminHome");
                }
                else if (res == -1)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn đã bị khóa.");
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập thất bại.");
            }

            return View();
        }
    }
}