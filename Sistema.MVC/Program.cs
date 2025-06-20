using Alertas.Modelos;
using APIConsumer;
using Microsoft.EntityFrameworkCore;
using Sistema.Modelos;
using DinkToPdf;
using DinkToPdf.Contracts;




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

      
        builder.Services.AddControllersWithViews();
        builder.Services.AddSingleton<IConverter, SynchronizedConverter>(provider =>
    new SynchronizedConverter(new PdfTools()));
        var app = builder.Build();
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
            pattern: "{controller=Account}/{action=Login}/{id?}");

        app.Run();
    }
}
