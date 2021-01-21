using Microsoft.EntityFrameworkCore;
using ProductProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductProject.DataAccessLayer.Concrete.EntityFramework
{
    public class ProductProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductProjectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<Product> Products { get; set; }
    }
}
