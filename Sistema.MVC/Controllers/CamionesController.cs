using APIConsumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema.Modelos; // Assuming you have a namespace for your models
namespace Sistema.MVC.Controllers
{
    public class CamionesController : Controller
    {
        // GET: CamionesController
        public ActionResult Index()
        {
            var data = Crud<Camion>.GetAll();
            return View(data);
        }

        // GET: CamionesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Camion>.GetById(id);
            return View(data);
        }

        // GET: CamionesController/Create
        public ActionResult Create()
        {
            ViewBag.Conductor = GetConductores();
            return View();
        }
        private List<SelectListItem> GetConductores()
        {
            var conductores = Crud<Conductor>.GetAll();
            return conductores.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nombre
            }).ToList();
        }
        // POST: CamionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Camion c)
        {
            try
            {
                Crud<Camion>.Create(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CamionesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Camion>.GetById(id);
            ViewBag.Conductor = GetConductores();
            return View(data);
        }

        // POST: CamionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Camion c)
        {
            try
            {
                Crud<Camion>.Update(id, c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CamionesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Camion>.GetById(id);
            return View();
        }

        // POST: CamionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Camion c)
        {
            try
            {
                Crud<Camion>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
