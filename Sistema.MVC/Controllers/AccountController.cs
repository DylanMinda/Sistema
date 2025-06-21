using Microsoft.AspNetCore.Mvc;
using Sistema.Modelos;

namespace Sistema.MVC.Controllers
{
    public class AccountController : Controller
    {
        // Simula una base de datos con 2 usuarios
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Email = "admin@ejemplo.com", Contraseña = "1234" },
            new Usuario { Id = 2, Email = "user@ejemplo.com", Contraseña = "abcd" }
        };

        // Método GET: Muestra el formulario de login
        public IActionResult Login()
        {
            return View();
        }

        // Método POST: Maneja el inicio de sesión
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var usuarioValido = usuarios.FirstOrDefault(u => u.Email == usuario.Email && u.Contraseña == usuario.Contraseña);

            if (usuarioValido != null)
            {
                // Guardamos en la sesión que el usuario ha iniciado sesión
                HttpContext.Session.SetString("UserEmail", usuario.Email);

                // Redirigimos al usuario a la página principal
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ErrorMessage"] = "Correo electrónico o contraseña incorrectos.";
                return View();
            }
        }
    }
}
