using DemoShop.Core.Contracts;
using DemoShop.Core.Models;
using DemoShop.Core.ViewModels;
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
        public ActionResult Index(string Category=null)
        {
            List<Product> products;
            List<ProductCategory> productCategories = productCategoriesCtx.Collection().ToList();

            if (Category == null)
            {
                products = productsCtx.Collection().ToList();
            }
            else
            {
                products = productsCtx.Collection().Where(p => p.Category == Category).ToList();
            }

            ProductListViewModel vm = new ProductListViewModel();
            vm.Products = products;
            vm.ProductCategories = productCategories;

            return View(vm);
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