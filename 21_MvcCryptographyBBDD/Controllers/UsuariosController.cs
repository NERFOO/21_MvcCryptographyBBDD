using _21_MvcCryptographyBBDD.Models;
using _21_MvcCryptographyBBDD.Repositories;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace _21_MvcCryptographyBBDD.Controllers
{
    public class UsuariosController : Controller
    {

        private RepositoryUsuarios repo;
        private IWebHostEnvironment hostEnvironment;

        public UsuariosController(RepositoryUsuarios repo, IWebHostEnvironment hostEnvironment)
        {
            this.repo = repo;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string nombre, string email, string password, IFormFile imagen)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
            var path = Path.Combine(baseUrl, imagen.FileName);
            var path2 = Path.Combine("wwwroot","img", imagen.FileName);

            using (Stream stream = new FileStream(path2, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }

            await this.repo.RegisterUser(nombre, email, password, imagen.FileName);

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
