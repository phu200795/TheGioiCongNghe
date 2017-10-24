using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGioiCongNghe.Models
{
    public class Article_category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Parent_Id { get; set; }
    }
}