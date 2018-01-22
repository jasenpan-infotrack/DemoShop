using DemoShop.Core.Contracts;
using DemoShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> productsCtx;
        IRepository<ProductCategory> productCategoriesCtx;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            productsCtx = productContext;
            productCategoriesCtx = productCategoryContext;
        }
        public ActionResult Index()
        {
            List<Product> products = productsCtx.Collection().ToList();
            return View(products);
        }

        public ActionResult Details(string id)
        {
            Product product = productsCtx.Find(id);
            if (product == null) return HttpNotFound();

            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}