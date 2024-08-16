using Clase10_AspNetCore_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Clase10_AspNetCore_WebAPI.Data
{
    public class AppDbContext: DbContext
    {
        //Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        //DbSet para la tabla WeatherForecasts
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
