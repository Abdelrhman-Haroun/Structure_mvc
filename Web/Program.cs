using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Repositories;
using Entities.IRepositories;
using Microsoft.Extensions.Configuration;
namespace Web
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(4))
             .AddDefaultTokenProviders()
             .AddDefaultUI()
             .AddEntityFrameworkStores<ApplicationDbContext>();


            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();
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
            app.MapRazorPages();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();

        }
    }
}
