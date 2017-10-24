using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGioiCongNghe.Models;
using TheGioiCongNghe.ViewModels;
namespace TheGioiCongNghe.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public AdminController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET: Admin
        //Danh mục
        public ActionResult ListProtductModel()
        {
            var product_category = dbContext.Product_categorys;
            return View(product_category);
        }
        //Tạo Categoty 
        public ActionResult CreateProductCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProductCategory(Product_category viewModel)
        {
            var category = new Product_category
            {
                Title = viewModel.Title,
                Parent_Id = viewModel.Parent_Id
            };
            dbContext.Product_categorys.Add(category);
            dbContext.SaveChanges();
            return RedirectToAction("ListProtductModel", "Admin");
        }
        //Sữa Categoty
        public ActionResult EditProductCategory(int id)
        {
            var category = dbContext.Product_categorys.Single(c => c.Id == id);
            var categorys = new Product_category
            {
                Id = category.Id,
                Title = category.Title,
                Parent_Id = category.Parent_Id
            };
            return View(categorys);
        }
        [HttpPost]
        public ActionResult EditProductCategory(Product_category viewModel)
        {
            var category = dbContext.Product_categorys.Single(c => c.Id == viewModel.Id);
            category.Title = viewModel.Title;
            category.Parent_Id = viewModel.Parent_Id;
            dbContext.SaveChanges();

            return RedirectToAction("ListProtductModel", "Admin");
        }
        // Xóa Categoty
        public ActionResult DeleteProductCategory(int id)
        {
            var category = dbContext.Product_categorys.Single(c => c.Id == id);
            var categorys = new Product_category
            {
                Id = category.Id,
                Title = category.Title,
                Parent_Id = category.Parent_Id
            };
            return View(categorys);
        }
        [HttpPost]
        public ActionResult DeleteProductCategory(Product_category viewModel)
        {
            var category = dbContext.Product_categorys.Single(c => c.Id == viewModel.Id);
            dbContext.Product_categorys.Remove(category);
            dbContext.SaveChanges();
            return RedirectToAction("ListProtductModel", "Admin");
        }
        //-----------------------------------Product-manager--------------------------------------------//
        //Danh Mục
        public ActionResult ListProductManager()
        {
            var product_manager = dbContext.Product_managers;
            return View(product_manager);
        }

        //Tao Manager
        public ActionResult CreateProductManager()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProductManager(Product_manager viewModel, HttpPostedFileBase chonHinh)
        {
            if (chonHinh != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(chonHinh.FileName);
                string extensions = Path.GetExtension(chonHinh.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extensions;
                viewModel.Product_image = "~/Content/images/" + fileName;
                chonHinh.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            var manager = new Product_manager
            {
                Cat_Id = viewModel.Cat_Id,
                DateTime = viewModel.DateTime,
                Product_Alias = viewModel.Product_Alias,
                Product_category = viewModel.Product_category,
                Product_Description = viewModel.Product_Description,
                Product_image = viewModel.Product_image,
                Product_Price = viewModel.Product_Price,
                Status = true,
                Title = viewModel.Title
            };
            dbContext.Product_managers.Add(manager);
            dbContext.SaveChanges();
            return RedirectToAction("ListProductManager", "Admin");
        }
        //Sữa Manager
        public ActionResult EditProductManager(int id)
        {
            var category = dbContext.Product_managers.Single(m => m.Id == id);
            var categorys = new Product_manager
            {
                Id = category.Id,
                Cat_Id = category.Cat_Id,
                DateTime = category.DateTime,
                Product_Alias = category.Product_Alias,
                Product_category = category.Product_category,
                Product_Description = category.Product_Description,
                Product_image = category.Product_image,
                Product_Price = category.Product_Price,
                Status = category.Status,
                Title = category.Title
            };

            return View(categorys);
        }
        [HttpPost]
        public ActionResult EditProductManager(Product_manager viewModel, HttpPostedFileBase chonHinh)
        {
            if (chonHinh != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(chonHinh.FileName);
                string extensions = Path.GetExtension(chonHinh.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extensions;
                viewModel.Product_image = "~/Content/images/" + fileName;
                chonHinh.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            var category = dbContext.Product_managers.Single(m => m.Id == viewModel.Id);

            category.Cat_Id = viewModel.Cat_Id;
            category.DateTime = viewModel.DateTime;
            category.Product_Alias = viewModel.Product_Alias;
            category.Product_category = viewModel.Product_category;
            category.Product_Description = viewModel.Product_Description;
            category.Product_image = viewModel.Product_image;
            category.Product_Price = viewModel.Product_Price;
            category.Title = viewModel.Title;
            dbContext.SaveChanges();
            return RedirectToAction("ListProductManager", "Admin");
        }
        //Xóa Manager
        public ActionResult DeleteProductManager(int id)
        {
            var category = dbContext.Product_managers.Single(m => m.Id == id);
            var categorys = new Product_manager
            {
                Id = category.Id,
                Cat_Id = category.Cat_Id,
                DateTime = category.DateTime,
                Product_Alias = category.Product_Alias,
                Product_category = category.Product_category,
                Product_Description = category.Product_Description,
                Product_image = category.Product_image,
                Product_Price = category.Product_Price,
                Status = category.Status,
                Title = category.Title
            };

            return View(categorys);
        }
        [HttpPost]
        public ActionResult DeleteProductManager(Product_manager viewModel)
        {
            var category = dbContext.Product_managers.Single(m => m.Id == viewModel.Id);
            category.Status = false;
            dbContext.SaveChanges();
            return RedirectToAction("ListProductManager", "Admin");
        }
        //-----------------------------------Article-category--------------------------------------------//
        //Danh mục
        public ActionResult ListArticleCategory()
        {
            var article_category = dbContext.Article_categorys;
            return View(article_category);
        }
        //Tạo Categoty 
        public ActionResult CreateArticleCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateArticleCategory(Article_category viewModel)
        {
            var category = new Article_category
            {
                Title = viewModel.Title,
                Parent_Id = viewModel.Parent_Id
            };
            dbContext.Article_categorys.Add(category);
            dbContext.SaveChanges();
            return RedirectToAction("ListArticleCategory", "Admin");
        }
        //Sữa Categoty
        public ActionResult EditArticleCategory(int id)
        {
            var category = dbContext.Article_categorys.Single(c => c.Id == id);
            var categorys = new Article_category
            {
                Id = category.Id,
                Title = category.Title,
                Parent_Id = category.Parent_Id
            };
            return View(categorys);
        }
        [HttpPost]
        public ActionResult EditArticleCategory(Article_category viewModel)
        {
            var category = dbContext.Article_categorys.Single(c => c.Id == viewModel.Id);
            category.Title = viewModel.Title;
            category.Parent_Id = viewModel.Parent_Id;
            dbContext.SaveChanges();

            return RedirectToAction("ListArticleCategory", "Admin");
        }
        // Xóa Categoty
        public ActionResult DeleteArticleCategory(int id)
        {
            var category = dbContext.Article_categorys.Single(c => c.Id == id);
            var categorys = new Article_category
            {
                Id = category.Id,
                Title = category.Title,
                Parent_Id = category.Parent_Id
            };
            return View(categorys);
        }
        [HttpPost]
        public ActionResult DeleteArticleCategory(Product_category viewModel)
        {
            var category = dbContext.Article_categorys.Single(c => c.Id == viewModel.Id);
            dbContext.Article_categorys.Remove(category);
            dbContext.SaveChanges();
            return RedirectToAction("ListProtductModel", "Admin");
        }
        //-----------------------------------Article-manager--------------------------------------------//
        //Danh mục
        public ActionResult ListArticleManager()
        {
            var article_manager = dbContext.Article_managers;
            return View(article_manager);
        }

        //Tạo Categoty 
        public ActionResult CreateArticleManager()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateArticleManager(Article_manager viewModel, HttpPostedFileBase chonHinh)
        {
            if (chonHinh != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(chonHinh.FileName);
                string extensions = Path.GetExtension(chonHinh.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extensions;
                viewModel.Article_image = "~/Content/images/" + fileName;
                chonHinh.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            var manager = new Article_manager
            {
                Article_Alias = viewModel.Article_Alias,
                Article_Description = viewModel.Article_Description,
                Article_category = viewModel.Article_category,
                Article_image = viewModel.Article_image,
                Cat_Id = viewModel.Cat_Id,
                DateTime = viewModel.DateTime,
                Status = viewModel.Status,
                Title = viewModel.Title
            };
            dbContext.Article_managers.Add(manager);
            dbContext.SaveChanges();
            return RedirectToAction("ListArticleManager", "Admin");
        }
        //Sữa Categoty
        public ActionResult EditArticleManager(int id)
        {
            var manager = dbContext.Article_managers.Single(c => c.Id == id);
            var managers = new Article_manager
            {
                Article_Alias = manager.Article_Alias,
                Article_Description = manager.Article_Description,
                Article_category = manager.Article_category,
                Article_image = manager.Article_image,
                Cat_Id = manager.Cat_Id,
                DateTime = manager.DateTime,
                Status = manager.Status,
                Title = manager.Title
            };
            return View(managers);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditArticleManager(Article_manager viewModel, HttpPostedFileBase chonHinh)
        {
            if (chonHinh != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(chonHinh.FileName);
                string extensions = Path.GetExtension(chonHinh.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extensions;
                viewModel.Article_image = "~/Content/images/" + fileName;
                chonHinh.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            var manager = dbContext.Article_managers.Single(c => c.Id == viewModel.Id);
            manager.Article_Alias = viewModel.Article_Alias;
            manager.Article_Description = viewModel.Article_Description;
            manager.Article_category = viewModel.Article_category;
            manager.Article_image = viewModel.Article_image;
            manager.Cat_Id = viewModel.Cat_Id;
            manager.DateTime = viewModel.DateTime;
            manager.Status = viewModel.Status;
            manager.Title = viewModel.Title;
            dbContext.SaveChanges();

            return RedirectToAction("ListArticleManager", "Admin");
        }
        // Xóa Categoty
        public ActionResult DeleteArticleManager(int id)
        {
            var manager = dbContext.Article_managers.Single(c => c.Id == id);
            var managers = new Article_manager
            {
                Article_Alias = manager.Article_Alias,
                Article_Description = manager.Article_Description,
                Article_category = manager.Article_category,
                Article_image = manager.Article_image,
                Cat_Id = manager.Cat_Id,
                DateTime = manager.DateTime,
                Status = manager.Status,
                Title = manager.Title
            };
            return View(managers);
        }
        [HttpPost]
        public ActionResult DeleteArticleManager(Product_category viewModel)
        {
            var manager = dbContext.Article_managers.Single(c => c.Id == viewModel.Id);
            dbContext.Article_managers.Remove(manager);
            dbContext.SaveChanges();
            return RedirectToAction("ListArticleManager", "Admin");
        }
    }
}


