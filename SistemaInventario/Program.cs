using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.AccesoDatos.Data;
namespace SistemaInventario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("SistemaInventarioContextConnection") ?? throw new InvalidOperationException("Connection string 'SistemaInventarioContextConnection' not found.");

            builder.Services.AddDbContext<SistemaInventarioContext>(options => 
            options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SistemaInventarioContext>();

            // Add services to the container. Servicios
            builder.Services.AddControllersWithViews();

            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Redirecci�n HTTPS y Archivos Est�ticos:
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Routing y Autorizaci�n:
            app.UseRouting();

            app.UseAuthorization();


            // Configuraci�n de Rutas de Controlador:
            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Inventario}/{controller=Home}/{action=Index}/{id?}");

            // Ejecuci�n de la Aplicaci�n:
            app.Run();
        }
    }
}
