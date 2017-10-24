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
    }
}