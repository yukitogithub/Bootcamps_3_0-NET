using FinalApp_ECommerce_DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_DataAccessLayer.Data
{
    public class ECommerceDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Se puede usar Fluent API para configurar las relaciones entre las entidades
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Profile);

            //Se puede hacer la carga inicial aquí pero nosotros vamos a hacerlo en el Program.cs usando una clase aparte como en SeedData.cs
            //modelBuilder.Entity<Category>().HasData(
            //    new Category { Id = 1, Name = "Electronics", Description = "Electronic Items" },
            //    new Category { Id = 2, Name = "Clothes", Description = "Clothes Items" },
            //    new Category { Id = 3, Name = "Grocery", Description = "Grocery Items" }
            //);

            //modelBuilder.Entity<Product>().HasData(
            //    new Product { Id = 1, Name = "Laptop", Price = 50000, CategoryId = 1 },
            //    new Product { Id = 2, Name = "Mobile", Price = 20000, CategoryId = 1 },
            //    new Product { Id = 3, Name = "Shirt", Price = 1000, CategoryId = 2 },
            //    new Product { Id = 4, Name = "T-Shirt", Price = 500, CategoryId = 2 },
            //    new Product { Id = 5, Name = "Rice", Price = 50, CategoryId = 3 },
            //    new Product { Id = 6, Name = "Wheat", Price = 40, CategoryId = 3 }
            //);

            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Id = 1,
            //        Name = "User1",
            //        Email = ""
            //    }
            //);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=.;Database=ECommerceDb;Trusted_Connection=True;");
        }
    }
}
