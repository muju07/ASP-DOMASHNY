using DependencyInjection.Models;

namespace DependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //это внедрение с сопоставлением службы с типом реализации
            builder.Services.AddScoped<IRepository, Repository>();
            //Это внедрение зависмости для одного типа
            builder.Services.AddSingleton<IStorage, Storage>();
            builder.Services.AddTransient<ProductSum>();
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