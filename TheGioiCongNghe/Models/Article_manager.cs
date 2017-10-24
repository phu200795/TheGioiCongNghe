using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheGioiCongNghe.Models
{
    public class Article_manager
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Article_Alias { get; set; }
        public Article_category Article_category { get; set; }
        [Required]
        public int Cat_Id { get; set; }

        public string Article_Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Article_image { get; set; }
        public bool Status { get; set; }
    }
}