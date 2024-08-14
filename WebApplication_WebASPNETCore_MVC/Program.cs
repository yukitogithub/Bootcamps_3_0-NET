using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication_WebASPNETCore_MVC.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApplication_WebASPNETCore_MVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication_WebASPNETCore_MVCContext") ?? throw new InvalidOperationException("Connection string 'WebApplication_WebASPNETCore_MVCContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
