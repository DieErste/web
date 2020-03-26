using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShop.Data.Models;

namespace MyShop.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<Item> item { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<ShopCartItem> shopCartItem { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<OrderDetail> orderDetail { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Login> login { get; set; }
        public DbSet<Img> img { get; set; }
    }
}
