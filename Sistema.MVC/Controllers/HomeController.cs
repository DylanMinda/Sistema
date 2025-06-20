using Microsoft.AspNetCore.Mvc;

namespace Sistema.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
