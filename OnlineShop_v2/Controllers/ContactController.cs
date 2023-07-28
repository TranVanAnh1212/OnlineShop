using OnlineShopModel.DAO;
using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_v2.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var contactDAO = new ContactDAO().GetContact();
            return View(contactDAO);
        }

        public JsonResult SendFeedBack(string feedbackerName, string feedbackerEmail, string feedbackerContent, string feedbackerPhone, string feedbackerAddress)
        {
            var feedback = new Feedback();
            feedback.Name = feedbackerName;
            feedback.Email = feedbackerEmail;
            feedback.Phone = feedbackerPhone;
            feedback.Address = feedbackerAddress;
            feedback.Content = feedbackerContent;
            feedback.CreatedDate = DateTime.Now;
            feedback.Status = true;

            var result = new FeedbackDAO().Insert(feedback);

            if (result > 0)
            {
                return Json(new { status = true });
            }
            else
            {
                return Json(new { status = false });
            }
        }
    }
}