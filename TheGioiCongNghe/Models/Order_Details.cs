using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGioiCongNghe.Models
{
    public class Order_Details
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}