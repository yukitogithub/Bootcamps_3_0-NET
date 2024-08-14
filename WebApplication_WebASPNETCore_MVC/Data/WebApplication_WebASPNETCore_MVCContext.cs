using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication_WebASPNETCore_MVC.Models;

namespace WebApplication_WebASPNETCore_MVC.Data
{
    public class WebApplication_WebASPNETCore_MVCContext : DbContext
    {
        public WebApplication_WebASPNETCore_MVCContext (DbContextOptions<WebApplication_WebASPNETCore_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication_WebASPNETCore_MVC.Models.Compra> Compra { get; set; } = default!;
    }
}
