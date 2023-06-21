using Final_Project.Models;
using Final_Project.Repository;

using Final_Project.ViewModelRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Final_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                option =>
                {
                    option.Password.RequireUppercase = false;
                }
                ).AddEntityFrameworkStores<MyContext>();

            builder.Services.AddDbContext<MyContext>(o =>
            o.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IProductWithDepartmentName, ProductsWithDepartmentNameRepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}