using BotDetect.Web.Mvc;
using Facebook;
using OnlineShop_v2.Common;
using OnlineShop_v2.Models;
using OnlineShopModel.DAO;
using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_v2.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Logout()
        {
            Session[Common.CommonConstants.CUSTOMER_SESSION] = null;
            return Redirect("/");
        }
        
        // GET: Customer
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[CaptchaValidationActionFilter("CaptchaCode", "ExampleCaptcha", "Captcha không đúng!")]
        public ActionResult Register(CustomerModel cusModel)
        {
            if (ModelState.IsValid)
            {
                var isCheckedUsername = new CustomerDAO().CheckUserName(cusModel.Username);
                if (isCheckedUsername)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại.");
                }
                else
                {
                    var customer = new Customer();
                    customer.Username = cusModel.Username;
                    customer.Password = cusModel.Password;
                    customer.CreatedDate = DateTime.Now;
                    customer.status = true;
                    customer.avatarUrl = "~\\Data\\images\\default-fallback-image.jpg";

                    var result = new CustomerDAO().Insert(customer);

                    if (result > 0)
                    {
                        return RedirectToAction("CustomerLogin");
                    }
                }
            }
            else
            {
                // Reset the captcha if your app's workflow continues with the same view
                //MvcCaptcha.ResetCaptcha("RegisterCaptcha");
                ModelState.AddModelError("", "Có lỗi xảy ra");
                return View();
            }

            return View();

        }

        public ActionResult CustomerLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerLogin(CustomerLoginVM customer)
        {
            if (ModelState.IsValid)
            {
                var result = new CustomerDAO().GetUserByUserName(customer.UserName, customer.Password);

                if (result)
                {
                    var custSession = new CustomerLogin();
                    custSession.Username = customer.UserName;
                    Session.Add(CommonConstants.CUSTOMER_SESSION, custSession);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tên tài khoản hoặc mật khẩu");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Không thể đăng nhập, có lỗi xảy ra.");
                return View();
            }

            return View();
        }

        //Đăng nhập với facebook
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        public ActionResult LoginWithFB()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["fbAppID"],
                client_secret = ConfigurationManager.AppSettings["fbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        private ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["fbAppID"],
                client_secret = ConfigurationManager.AppSettings["fbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;

            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name, middle name etc
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;

                var cust = new Customer();
                cust.Username = userName;
                cust.Email = email;
                cust.DisplayName = firstname + " " + middlename + " " + lastname;
                cust.status = true;
                var addDBResult = new CustomerDAO().InsertCusFB(cust);

                if (addDBResult > 0)
                {
                    var custSession = new CustomerLogin();
                    custSession.Username = cust.Username;
                    Session.Add(CommonConstants.CUSTOMER_SESSION, custSession);
                }
            }

            return Redirect("/");   
        }
    }
}