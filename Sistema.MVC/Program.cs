using Alertas.Modelos;
using APIConsumer;
using Microsoft.EntityFrameworkCore;
using Sistema.Modelos;


public class Program
{
    public static void Main(string[] args)
    {
        // Configuración de los endpoints de las APIs
        Crud<Camion>.EndPoint = "https://localhost:7087/api/Camiones";
        Crud<Conductor>.EndPoint = "https://localhost:7087/api/Conductores";
        Crud<Mantenimiento>.EndPoint = "https://localhost:7087/api/Mantenimientos";
        Crud<Taller>.EndPoint = "https://localhost:7087/api/Talleres";
        Crud<Usuario>.EndPoint = "https://localhost:7087/api/Usuarios";
        Crud<Alerta>.EndPoint = "https://localhost:7121/api/Alertas";
        Crud<Sensor>.EndPoint = "https://localhost:7121/api/Sensores";

        var builder = WebApplication.CreateBuilder(args);

        // Configuración de las sesiones
        builder.Services.AddDistributedMemoryCache();  // Necesario para almacenar la sesión en memoria
        builder.Services.AddSession(options => {
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Habilitar el middleware de sesión
        app.UseSession();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Account}/{action=Login}/{id?}");

        app.Run();
    }
}
