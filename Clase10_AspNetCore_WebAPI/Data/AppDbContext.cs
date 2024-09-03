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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WeatherForecast>().Property(wf => wf.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<WeatherForecast>().HasData(
                new WeatherForecast { Id = 1, Date = new DateOnly(2024,08,16), TemperatureC = 20, Summary = "Hot" },
                new WeatherForecast { Id = 2, Date = new DateOnly(2024, 08, 17), TemperatureC = 25, Summary = "Cold" },
                new WeatherForecast { Id = 3, Date = new DateOnly(2024, 08, 18), TemperatureC = 30, Summary = "Warm" }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=WeatherForecastDB;Trusted_Connection=True;");
        }
    }
}
