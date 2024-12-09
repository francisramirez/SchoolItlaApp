using Microsoft.EntityFrameworkCore;
using SchoolItlaApp.Data.Daos;
using SchoolItlaApp.Data.Interfaces;

namespace SchoolItlaApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<Data.Context.SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb")));

            builder.Services.AddScoped<IDaoDepartment, DaoDepartment>();

            builder.Services.AddControllersWithViews();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}