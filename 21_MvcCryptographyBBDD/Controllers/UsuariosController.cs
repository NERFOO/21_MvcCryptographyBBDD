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
                //ViewData["Host"] = Request.Host;
                //string rootPath = this.hostEnvironment.WebRootPath;
                //string path = Path.Combine(rootPath, "img", user.Imagen);

                //using (Stream stream = new FileStream(path, FileMode.Create))
                //{
                //    path.CopyTo(stream);
                //}

                return View(user);
            }
        }

    }
}
