using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.Modelos; // Assuming you have a namespace for your models
using APIConsumer;
namespace Sistema.MVC.Controllers
{
    public class ConductoresController : Controller
    {
        // GET: ConductoresController
        public ActionResult Index()
        {
            var data = Crud<Conductor>.GetAll(); // Fetch all Conductores using the API consumer
            return View(data);
        }

        // GET: ConductoresController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Conductor>.GetById(id); // Fetch a specific Conductor by ID
            return View(data);
        }

        // GET: ConductoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConductoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Conductor c)
        {
            try
            {
                Crud<Conductor>.Create(c); // Create a new Conductor using the API consumer
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConductoresController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Conductor>.GetById(id); // Fetch a specific Conductor by ID for editing
            return View();
        }

        // POST: ConductoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Conductor c)
        {
            try
            {
                Crud<Conductor>.Update(id, c); // Update the Conductor using the API consumer
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConductoresController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Conductor>.GetById(id); // Fetch a specific Conductor by ID for deletion confirmation
            return View(data);
        }

        // POST: ConductoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Conductor c)
        {
            try
            {
                Crud<Conductor>.Delete(id); // Delete the Conductor using the API consumer
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
