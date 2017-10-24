using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheGioiCongNghe.Models;
namespace TheGioiCongNghe.ViewModels
{
    public class CartItem
    {
        public Product_manager Product { get; set; }
        public Order Orders { get; set; }
        public int Quantity { get; set; }
       
    }
}