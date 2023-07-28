using Common;
using OnlineShop_v2.Models;
using OnlineShopModel.DAO;
using OnlineShopModel.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop_v2.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddToCart(long productID, int Quanlity)
        {
            var cartSession = Session[Common.CommonConstants.CartSession];
            var productCart = new ProductDAO().GetProductByID(productID);

            if (cartSession != null)
            {
                var list = (List<CartItem>)cartSession;

                if (list.Exists(x => x.product.ID == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.product.ID == productID)
                        {
                            item.Quanlity += 1;
                        }
                    }
                }
                else
                {
                    // Tạo đối tượng cart item
                    var cartItem = new CartItem();
                    cartItem.product = productCart;
                    cartItem.Quanlity = Quanlity;
                    list.Add(cartItem);

                    // gán vào session
                    Session[Common.CommonConstants.CartSession] = list;
                }
            }
            else
            {
                // Tạo đối tượng cart item
                var cartItem = new CartItem();
                cartItem.product = productCart;
                cartItem.Quanlity = Quanlity;
                var list = new List<CartItem>();
                list.Add(cartItem);

                // gán vào session
                Session[Common.CommonConstants.CartSession] = list;
            }
            return RedirectToAction("Index");

        }

        //[HttpPost]
        //public JsonResult AddToCartAjax(long productID, int Quantity)
        //{
        //    var sessionCart = Session[Common.CommonConstants.CartSession];
        //    var productCart = new ProductDAO().GetProductByID(productID);

        //    if (sessionCart != null)
        //    {
        //        var list = (List<CartItem>)sessionCart;

        //        if (list.Exists(x => x.product.ID == productID))
        //        {
        //            foreach (var item in list)
        //            {
        //                if (item.product.ID == productID)
        //                {
        //                    item.Quanlity += 1;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            // Tạo đối tượng cart item
        //            var cartItem = new CartItem();
        //            cartItem.product = productCart;
        //            cartItem.Quanlity = Quantity;
        //            list.Add(cartItem);

        //            // gán vào session
        //            Session[Common.CommonConstants.CartSession] = list;
        //        }
        //    }
        //    else
        //    {
        //        // Tạo đối tượng cart item
        //        var cartItem = new CartItem();
        //        cartItem.product = productCart;
        //        cartItem.Quanlity = Quantity;
        //        var list = new List<CartItem>();
        //        list.Add(cartItem);

        //        // gán vào session
        //        Session[Common.CommonConstants.CartSession] = list;
        //    }

        //    return Json(new { status = true });
        //}

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[Common.CommonConstants.CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.product.ID == item.product.ID);

                if (jsonItem != null)
                {
                    item.Quanlity = jsonItem.Quanlity;
                }
            }

            return Json(new
            {
                status = true,
            });
        }

        public JsonResult DeleteAll()
        {
            Session[Common.CommonConstants.CartSession] = null;

            return Json(new { status = true });
        }

        public JsonResult DeleteItem(long id)
        {
            var cartSession = (List<CartItem>)Session[Common.CommonConstants.CartSession];
            cartSession.RemoveAll(x => x.product.ID == id);
            Session[Common.CommonConstants.CartSession] = cartSession;

            return Json(new { status = true });
        }

        public ActionResult Payment()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string address, string phone, string email, string paymentMethod)
        {
            try
            {
                var order = new Order();
                order.CustomerID = 1;
                order.ConsigneeName = shipName;
                order.ConsigneePhone = phone;
                order.ConsigneeEmail = email;
                order.DiliveryAddress = address;
                order.CreatedDate = DateTime.Now;
                order.PaymentMethod = paymentMethod;
                order.ShippingMethod = "Giao hàng nhanh";

                var totalPrice = 0;
                var cartSession = (List<CartItem>)Session[Common.CommonConstants.CartSession];
                foreach (var item in cartSession)
                {
                    totalPrice += item.Quanlity * (int)item.product.Price;
                }

                order.TotalAmount = totalPrice;

                long orderID = new OrderDAO().Insert(order);

                if (orderID > 0)
                {

                    //string content = System.IO.File.ReadAllText(Server.MapPath("~/Asests/Client/Templates/NewOrder.html"));

                    //content = content.Replace("{{CustomerName}}", order.ConsigneeName);
                    //content = content.Replace("{{Phone}}", order.ConsigneePhone);
                    //content = content.Replace("{{Email}}", order.ConsigneeEmail);
                    //content = content.Replace("{{Address}}", order.DiliveryAddress);
                    //content = content.Replace("{{Total}}", order.TotalAmount.ToString("N0"));

                    //var toEmailAddress = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                    //new EmailHelper().SendEmail(toEmailAddress, "Đơn hàng mới từ OnlineShop", content);

                    Session[Common.CommonConstants.CartSession] = null;
                    return RedirectToAction("Index", "Order");

                }
                else
                {
                    return View();
                }
            }
            catch (Exception ee)
            {
                return View();
            }

        }
    }
}