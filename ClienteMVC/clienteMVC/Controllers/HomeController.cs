using System.Diagnostics;
using clienteMVC.Auxiliar;
using clienteMVC.DTOs;
using clienteMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace clienteMVC.Controllers
{
    public class HomeController : Controller
    {
        private string _urlLogin;

        public HomeController(IConfiguration config)
        {
            _urlLogin = config.GetValue<string>("URLApiLogin");
        }


        public IActionResult Index(string error)
        {
            ViewBag.Error = error;
            return View();

        }
        public IActionResult Login(string error)
        {
            ViewBag.Error = error;
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {

            if(email == null || password == null)
            {
                ViewBag.Error = "Datos incorrectos";
                return View();
            }
            UsuarioDTO usuario = null;

            try
            {

                LoginDTO logueado = new LoginDTO();
                logueado.Email = email;
                logueado.Password = password;

                HttpResponseMessage respuesta = AuxiliarClienteHttp.EnviarSolicitud(_urlLogin, "POST", logueado, null);
                string body = AuxiliarClienteHttp.ObtenerBody(respuesta);

                if (respuesta.IsSuccessStatusCode)
                {
                    usuario = JsonConvert.DeserializeObject<UsuarioDTO>(body);
                    HttpContext.Session.SetString("email", usuario.Email);
                    HttpContext.Session.SetInt32("usuarioId", usuario.Id);
                    HttpContext.Session.SetString("rol", usuario.Rol);
                    HttpContext.Session.SetString("token", usuario.Token);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = body;
                    return View();
                }
                
            }
            catch (Exception)
            {
                ViewBag.Error = "Error interno, intente mas tarde";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}