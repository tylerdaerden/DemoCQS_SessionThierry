using F23L034_GestContact_Cqs.WebApp.Infrastructure;
using F23L034_GestContact_Cqs.WebApp.Models.Repositories;
using F23L034_GestContact_Cqs.WebApp.Models.Services;
using System.Data;
using System.Data.SqlClient;

namespace F23L034_GestContact_Cqs.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ISessionManager, SessionManager>();

            #region Ajout des services de sessions
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(opt =>
            {
                opt.Cookie.Name = ".GestContactCqs.Cookie";
                opt.Cookie.HttpOnly = false;
                opt.IOTimeout = TimeSpan.FromMinutes(10);
            });
            #endregion

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(configuration.GetConnectionString("F23L034_GestContact_Cqs")));
            builder.Services.AddScoped<IAuthRepository, AuthService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();

            app.UseHttpsRedirection();
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