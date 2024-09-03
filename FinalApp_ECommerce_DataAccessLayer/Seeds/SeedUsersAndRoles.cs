using FinalApp_ECommerce_DataAccessLayer.Data;
using FinalApp_ECommerce_DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_DataAccessLayer.Seeds
{
    public class SeedUsersAndRoles
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

                if (!context.Roles.Any())
                {
                    var adminRole = new IdentityRole<int>("ADMIN");
                    await roleManager.CreateAsync(adminRole);

                    var userRole = new IdentityRole<int>("USER");
                    await roleManager.CreateAsync(userRole);
                }

                if (!context.Users.Any())
                {
                    var user = new User
                    {
                        UserName = "admin",
                        Email = "admin@email.com",
                        Name = "admin"
                    };

                    await userManager.CreateAsync(user, "adminadmin");
                    await userManager.AddToRoleAsync(user, "ADMIN");
                }
            }
        }
    }
}
