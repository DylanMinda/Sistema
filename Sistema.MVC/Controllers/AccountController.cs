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
        public IActionResult Login(Usuario usuario)
        {
            // Buscar al usuario en la "base de datos" (lista simulada)
            var usuarioValido = usuarios.FirstOrDefault(u => u.Email == usuario.Email && u.Contraseña == usuario.Contraseña);

            if (usuarioValido != null)
            {
                // Si el usuario es válido, redirigir a la página principal
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Si las credenciales son incorrectas, mostrar un mensaje de error
                ViewData["ErrorMessage"] = "Correo electrónico o contraseña incorrectos.";
                return View();
            }
        }
    }
}
