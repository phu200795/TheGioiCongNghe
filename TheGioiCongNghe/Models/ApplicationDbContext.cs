using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TheGioiCongNghe.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product_category> Product_categorys { get; set; }
        public DbSet<Product_manager> Product_managers { get; set; }
        public DbSet<Article_category> Article_categorys { get; set; }
        public DbSet<Article_manager> Article_managers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Details> Order_Detailss { get; set; }
        public ApplicationDbContext()
            : base("TheGioiCongNghe", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}