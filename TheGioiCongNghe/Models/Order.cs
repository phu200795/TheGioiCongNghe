using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGioiCongNghe.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatDate { get; set; }
        public int CustomerID { get; set; }
        public string ShipName { get; set; }
        public string ShipMobie { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
            
    }
}