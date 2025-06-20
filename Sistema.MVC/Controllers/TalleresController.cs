using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.Modelos;
using APIConsumer;
namespace Sistema.MVC.Controllers
{
    public class TalleresController : Controller
    {
        // GET: TalleresController
        public ActionResult Index()
        {
            var data = Crud<Taller>.GetAll();
            return View(data);
        }

        // GET: TalleresController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Taller>.GetById(id);
            return View(data);
        }

        // GET: TalleresController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: TalleresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Taller ta)
        {
            try
            {
                Crud<Taller>.Create(ta);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TalleresController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Taller>.GetById(id);
            return View();
        }

        // POST: TalleresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Taller t)
        {
            try
            {
                Crud<Taller>.Update(id, t); // Assuming you have a method to update the Talle
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TalleresController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Taller>.GetById(id);
            return View(data);
        }

        // POST: TalleresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Taller t)
        {
            try
            {
                Crud<Taller>.Delete(id); // Assuming you have a method to delete the Taller
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
