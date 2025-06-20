using APIConsumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema.Modelos;

namespace Sistema.MVC.Controllers
{
    public class MantenimientosController : Controller
    {
        // GET: MantinimientosController
        public ActionResult Index()
        {
            var data = Crud<Mantenimiento>.GetAll(); // Fetch all Mantenimientos using the API consumer
            return View(data);
        }

        // GET: MantinimientosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Mantenimiento>.GetById(id); // Fetch a specific Mantenimiento by ID

            // Obtener el Camión relacionado y los Mantenimientos asociados
            var camiones = Crud<Camion>.GetAll();
            var mantenimientoRelacionado = Crud<Mantenimiento>.GetAll()
                .Where(m => m.CamionId == data.CamionId)
                .ToList();

            // Pasar los datos a la vista
            ViewBag.MantenimientosRelacionados = mantenimientoRelacionado;
            ViewBag.Camion = camiones.FirstOrDefault(c => c.Id == data.CamionId);

            return View(data);
        }

        // GET: MantinimientosController/Create
        public ActionResult Create()
        {
            ViewBag.Taller = GetTaller();
            ViewBag.Camion = GetCamion();
            return View();
        }

        private List<SelectListItem> GetTaller()
        {
            var taller = Crud<Taller>.GetAll();
            return taller.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nombre
            }).ToList();
        }

        private List<SelectListItem> GetCamion()
        {
            var camion = Crud<Camion>.GetAll();
            return camion.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Marca
            }).ToList();
        }

        // POST: MantinimientosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mantenimiento m)
        {
            try
            {
                Crud<Mantenimiento>.Create(m); // Create a new Mantenimiento using the API consumer
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MantinimientosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Mantenimiento>.GetById(id); // Fetch a specific Mantenimiento by ID for editing
            ViewBag.Taller = GetTaller();
            ViewBag.Camion = GetCamion();
            return View(data);
        }

        // POST: MantinimientosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Mantenimiento m)
        {
            try
            {
                Crud<Mantenimiento>.Update(id, m); // Update the Mantenimiento using the API consumer
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MantinimientosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Mantenimiento>.GetById(id); // Fetch a specific Mantenimiento by ID for deletion confirmation
            return View(data);
        }

        // POST: MantinimientosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Mantenimiento m)
        {
            try
            {
                Crud<Mantenimiento>.Delete(id); // Delete the Mantenimiento using the API consumer
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
