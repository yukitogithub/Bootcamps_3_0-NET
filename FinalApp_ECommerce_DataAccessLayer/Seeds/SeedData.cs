using FinalApp_ECommerce_DataAccessLayer.Data;
using FinalApp_ECommerce_DataAccessLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_DataAccessLayer.Seeds
{
    public class SeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ECommerceDbContext>();

                //Si no usaramos Identity, podríamos hacer algo como esto:
                //if (!context.Users.Any())
                //{
                //    context.Add(new User()
                //    {
                //        Name = "Demo",
                //        Email = "demo@email.com",
                //        Password = "demo"
                //    });

                //    context.SaveChanges();
                //}

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category
                        {
                            Name = "Electronics",
                            Description = "Electronic Items"
                        },
                        new Category
                        {
                            Name = "Clothes",
                            Description = "Clothes Items"
                        },
                        new Category
                        {
                            Name = "Grocery",
                            Description = "Grocery Items"
                        }
                    );

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product
                        {
                            Name = "Laptop",
                            Price = 50000,
                            CategoryId = 1,
                            Stock = 100
                        },
                        new Product
                        {
                            Name = "Mobile",
                            Price = 20000,
                            CategoryId = 1,
                            Stock = 100
                        },
                        new Product
                        {
                            Name = "Shirt",
                            Price = 1000,
                            CategoryId = 2,
                            Stock = 100
                        },
                        new Product
                        {
                            Name = "T-Shirt",
                            Price = 500,
                            CategoryId = 2,
                            Stock = 100
                        },
                        new Product
                        {
                            Name = "Rice",
                            Price = 50,
                            CategoryId = 3,
                            Stock = 100
                        },
                        new Product
                        {
                            Name = "Wheat",
                            Price = 40,
                            CategoryId = 3,
                            Stock = 100
                        }
                    );

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
