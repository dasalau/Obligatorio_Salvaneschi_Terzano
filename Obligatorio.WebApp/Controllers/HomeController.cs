using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.Dtos.Usuarios;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.WebApp.Models;
using System.Diagnostics;

namespace Obligatorio.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICUUsuarioLogin<UsuarioDtoLogin, UsuarioDtoLogeado> _cuUsuarioLogin;
        public HomeController(ILogger<HomeController> logger, ICUUsuarioLogin<UsuarioDtoLogin, UsuarioDtoLogeado> cuUsuarioLogin)
        {
            _logger = logger;
            _cuUsuarioLogin = cuUsuarioLogin;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDtoLogin usuarioDtoLogin)
        {
            UsuarioDtoLogeado usuariologeado;

            try
            {
                usuariologeado = _cuUsuarioLogin.Execute(usuarioDtoLogin);
                HttpContext.Session.SetInt32("idUsuarioLogueado", usuariologeado.Id);
                HttpContext.Session.SetString("nombreUsuarioLogueado", usuariologeado.Nombre);


                if (usuariologeado.Rol == "Administrador")
                {
                    HttpContext.Session.SetString("rol", "Administrador");
                    return RedirectToAction("Index");
                }
                else if (usuariologeado.Rol == "Gerente")
                {
                    HttpContext.Session.SetString("rol", "Gerente");
                    return RedirectToAction("Index");
                }
                else //Empleado
                {
                    HttpContext.Session.SetString("rol", "Empleado");
                    return RedirectToAction("Index");
                }
            }

            catch (UsuarioExcepcion ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
