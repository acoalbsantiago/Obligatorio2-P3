using clienteMVC.Auxiliar;
using clienteMVC.DTOs;
using clienteMVC.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace clienteMVC.Controllers
{
    [LogueadoFilter]
    [AdminFilter]
    public class UsuarioController : Controller
    {
        private string _usuarioApiUrl;
        public UsuarioController(IConfiguration config) 
        {
            _usuarioApiUrl = config.GetValue<string>("URLApiUsuario");
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Reset()
        {
            string token = HttpContext.Session.GetString("token");
            string url = $"{_usuarioApiUrl}";

            try
            {
                HttpResponseMessage resp = AuxiliarClienteHttp.EnviarSolicitud(url, "GET", null, token);
                string body = AuxiliarClienteHttp.ObtenerBody(resp);
                if (!resp.IsSuccessStatusCode)
                {
                    ViewBag.Error = body;
                    return View();
                }

                var usuarios = JsonConvert.DeserializeObject<IEnumerable<UsuarioDTO>>(body);
                return View(usuarios);
            }
            catch (Exception)
            {
                ViewBag.Error = "Error interno, intente mas tarde";
                return View();
            }        
        }

        [HttpPost]
        public IActionResult Reset(int id)
        {
            string token = HttpContext.Session.GetString("token");
            string url = $"{_usuarioApiUrl}/ResetPassword/{id}";
            
            try
            {
                HttpResponseMessage resp = AuxiliarClienteHttp.EnviarSolicitud(url, "PUT", null, token);
                string body = AuxiliarClienteHttp.ObtenerBody(resp);

                if (!resp.IsSuccessStatusCode)
                {
                    ViewBag.Error = body;
                    return View();
                }
                var json = JsonConvert.DeserializeObject<dynamic>(body);
                string newPass = json.password;
                ViewBag.Mensaje = $"Nueva contraseña: {newPass}";


                var usuariosOk = JsonConvert.DeserializeObject<IEnumerable<UsuarioDTO>>(
                    AuxiliarClienteHttp.ObtenerBody(
                        AuxiliarClienteHttp.EnviarSolicitud(_usuarioApiUrl, "GET", null, token)
                    )
                );

                return View(usuariosOk);
            }
            catch (Exception)
            {
                ViewBag.Error = "Error interno, intente mas tarde";
                return View();
            }          
        }   
    }
}
