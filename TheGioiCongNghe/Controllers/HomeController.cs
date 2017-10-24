using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGioiCongNghe.Models;
using TheGioiCongNghe.ViewModels;
namespace TheGioiCongNghe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public HomeController()
        {
            dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var cha = dbContext.Product_categorys.ToList();
            var article_manager = dbContext.Article_managers.ToList();
            var product_manager = dbContext.Product_managers.ToList();
            ProductViewModels viewModel = new ProductViewModels();
            viewModel.Product_Categorys = cha;
            ViewBag.Product_Managers = product_manager;
            viewModel.Article_Managers = article_manager;
            return View(viewModel);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(int id)
        {
            var category = dbContext.Product_managers.Single(m => m.Id == id);
            return View(category);
            
        }
        
    }
}