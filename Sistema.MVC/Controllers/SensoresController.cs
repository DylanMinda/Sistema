using Alertas.Modelos;
using APIConsumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace Sistema.MVC.Controllers
{
    public class SensoresController : Controller
    {

        // GET: SensoresController
        public ActionResult Index()
        {
            var data = Crud<Sensor>.GetAll();
            return View(data);
        }

        // GET: SensoresController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Sensor>.GetById(id);
            return View(data);
        }

        // GET: SensoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SensoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sensor sensor)
        {
            try
            {

                if (sensor.Kilometraje > 10000)
                {

                    var alerta = new Alerta
                    {
                        Descripcion = $"El sensor del camión {sensor.CamionId} ha alcanzado {sensor.Kilometraje} km y necesita mantenimiento.",
                        fechaAlerta = DateTime.UtcNow,
                        SensorId = sensor.Id
                    };

                    Crud<Alerta>.Create(alerta);
                }

                Crud<Sensor>.Create(sensor);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var data = Crud<Sensor>.GetById(id);
            return View(data);
        }

        // POST: SensoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Sensor s)
        {
            try
            {
                Crud<Sensor>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
