using Alertas.Modelos;
using APIConsumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sistema.MVC.Controllers
{
    public class AlertasController : Controller
    {
        // GET: AlertasController
        public ActionResult Index()
        {
            var data = Crud<Alerta>.GetAll();
            return View(data);
        }
        public IActionResult GenerateAlertas()
        {

            var sensores = Crud<Sensor>.GetAll();


            foreach (var sensor in sensores)
            {

                if (sensor.Kilometraje > 10000)
                {

                    var alerta = new Alerta
                    {
                        Descripcion = $"El camión {sensor.CamionId} ha alcanzado {sensor.Kilometraje} km y necesita mantenimiento.",
                        fechaAlerta = DateTime.UtcNow,
                        SensorId = sensor.Id
                    };


                    Crud<Alerta>.Create(alerta);
                }
            }
            return RedirectToAction("Index", "Alertas");
        }
        // GET: AlertasController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Alerta>.GetById(id);
            return View();
        }

        // GET: AlertasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlertasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alerta a)
        {
            try
            {
                Crud<Alerta>.Create(a);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: AlertasController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Alerta>.GetById(id);
            return View();
        }

        // POST: AlertasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Alerta a)
        {
            try
            {
                Crud<Alerta>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
