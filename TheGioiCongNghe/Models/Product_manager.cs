using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheGioiCongNghe.Models
{
    public class Product_manager
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Product_Alias { get; set; }
        public Product_category Product_category { get; set; }
        [Required]
        public int Cat_Id { get; set; }
        public string Product_image { get; set; }
        public DateTime DateTime { get; set; }
        public string Product_Description { get; set; }
        public double Product_Price { get; set; }
        public bool Status { get; set; }
    }
}