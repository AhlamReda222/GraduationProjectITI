using GraduationProjectITI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GraduationProjectITI.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=AHLAM_REDA\\SQLEXPRESS;Database=FinalProjectMVC_ITI;Trusted_Connection=True;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Categories
            List<Category> categories = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Electronics", Description = "Electronic devices" },
                new Category { CategoryId = 2, Name = "Home & Kitchen", Description = "Home and kitchen appliances" },
                new Category { CategoryId = 3, Name = "Books", Description = "Books and educational materials" }
            };

            // Seed Products
            List<Product> products = new List<Product>
            {
                new Product { ProductId = 1, Price = 1200, Description = "Laptop", Quantity = 10, ImagePath = "/images/laptop.jpg", CategoryId = 1 },
                new Product { ProductId = 2, Price = 800, Description = "Tablet", Quantity = 15, ImagePath = "/images/tablet.jpg", CategoryId = 1 },
                new Product { ProductId = 3, Price = 50, Description = "Coffee Maker", Quantity = 25, ImagePath = "/images/coffee_maker.jpg", CategoryId = 2 },
                new Product { ProductId = 4, Price = 30, Description = "Book: C# Basics", Quantity = 100, ImagePath = "/images/book1.jpg", CategoryId = 3 },
                new Product { ProductId = 5, Price = 35, Description = "Book: ASP.NET Core", Quantity = 80, ImagePath = "/images/book2.jpg", CategoryId = 3 },
                new Product { ProductId = 6, Price = 100, Description = "Blender", Quantity = 20, ImagePath = "/images/blender.jpg", CategoryId = 2 },
                new Product { ProductId = 7, Price = 400, Description = "Smartphone", Quantity = 12, ImagePath = "/images/phone.jpg", CategoryId = 1 },
                new Product { ProductId = 8, Price = 60, Description = "Toaster", Quantity = 18, ImagePath = "/images/toaster.jpg", CategoryId = 2 },
                new Product { ProductId = 9, Price = 25, Description = "Book: EF Core Guide", Quantity = 70, ImagePath = "/images/book3.jpg", CategoryId = 3 },
                new Product { ProductId = 10, Price = 20, Description = "Book: LINQ in Action", Quantity = 60, ImagePath = "/images/book4.jpg", CategoryId = 3 }
            };

            // Apply HasData
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);


            base.OnModelCreating(modelBuilder);
        }
        #region Tables
        public virtual DbSet<Product>Products {  get; set; }
            public virtual DbSet<Category>Gategories{ get; set; }
        public virtual DbSet<User> Users { get; set; }


        #endregion
    }
}
