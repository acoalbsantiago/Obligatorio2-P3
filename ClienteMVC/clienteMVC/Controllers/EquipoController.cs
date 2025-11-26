using clienteMVC.Auxiliar;
using clienteMVC.DTOs;
using clienteMVC.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace clienteMVC.Controllers
{
    [LogueadoFilter]
    [GerenteFilter]
    public class EquipoController : Controller
    {
        private string _urlApiEquipos;
        
        public EquipoController(IConfiguration config) 
        {
            _urlApiEquipos = config.GetValue<String>("URLApiEquipo");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(decimal monto)
        {
            string url = $"{_urlApiEquipos}/{monto}";
            string token = HttpContext.Session.GetString("token");
            HttpResponseMessage respuesta = AuxiliarClienteHttp.EnviarSolicitud(url, "GET", null, token);
            string body = AuxiliarClienteHttp.ObtenerBody(respuesta);


            if (!respuesta.IsSuccessStatusCode)
            {
                ViewBag.Error = body;
                return View();
            }

            var equipos = JsonConvert.DeserializeObject<IEnumerable<EquipoDTO>>(body);
            ViewBag.Resultados = equipos;
            return View();


        }
    }
}
    