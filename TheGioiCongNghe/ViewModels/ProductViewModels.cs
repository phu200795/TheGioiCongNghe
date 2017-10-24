using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheGioiCongNghe.Models;

namespace TheGioiCongNghe.ViewModels
{
    public class ProductViewModels
    {
        public IEnumerable<Product_category> Product_Categorys { get; set; }
        public IEnumerable<Product_manager> Product_Managers { get; set; }
        public IEnumerable<Article_manager> Article_Managers { get; set; }
        public IEnumerable<Article_category> Article_Categorys { get; set; }
        public IEnumerable<Article_manager> Article_Managerss { get; set; }
    }
}