using System;
using DTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DTO.Models;

namespace DAL.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dataConnection")
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<AdminmOrderModel> AdminmOrderModels { get; set; }
    }
}