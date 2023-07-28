using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop_v2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}",
              new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{MetaTitle}-{categID}",
                defaults: new { controller = "ClientProduct", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop_v2.Controllers" }
            );

            routes.MapRoute(
                name: "View Product Detail",
                url: "chi-tiet-san-pham/{Name}/{prodID}",
                defaults: new { controller = "ClientProduct", action = "ViewProductDetail", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop_v2.Controllers" }
            );

            routes.MapRoute(
                name: "View cart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddToCart", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop_v2.Controllers" }
            );

            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop_v2.Controllers" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop_v2.Controllers" }
            );


            routes.MapRoute(
                name: "Order",
                url: "don-hang",
                defaults: new { controller = "Order", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop_v2.Controllers" }
            );

            routes.MapRoute(
                name: "Contact",
                url: "lien-he-voi-chung-toi",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop_v2.Controllers" }
            );

            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "Customer", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop_v2.Controllers" }
            );

            routes.MapRoute(
                name: "Customer login",
                url: "dang-nhap",
                defaults: new { controller = "Customer", action = "CustomerLogin", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop_v2.Controllers" }
            );

            routes.MapRoute(
                name: "Client search product",
                url: "tim-kiem",
                defaults: new { controller = "ClientProduct", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop_v2.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop_v2.Controllers" }
            );
        }
    }
}
