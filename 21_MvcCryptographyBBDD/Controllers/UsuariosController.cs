using _21_MvcCryptographyBBDD.Models;
using _21_MvcCryptographyBBDD.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _21_MvcCryptographyBBDD.Controllers
{
    public class UsuariosController : Controller
    {

        private RepositoryUsuarios repo;

        public UsuariosController(RepositoryUsuarios repo)
        {
            this.repo = repo;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string nombre, string email, string password, string imagen)
        {
            await this.repo.RegisterUser(nombre, email, password, imagen);

            ViewData["MENSAJE"] = "Usuario registrado correctamente";

            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string email, string password)
        {
            Usuario user = this.repo.LogInUser(email, password);

            if(user == null)
            {
                ViewData["MENSAJE"] = "Credenciales incorrectas";
                return View();
            } else
            {
                return View(user);
            }
        }

    }
}
