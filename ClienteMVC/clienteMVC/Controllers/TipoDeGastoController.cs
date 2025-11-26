using clienteMVC.Auxiliar;
using clienteMVC.DTOs;
using clienteMVC.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace clienteMVC.Controllers
{
    [LogueadoFilter]
    [AdminFilter]
    public class TipoDeGastoController : Controller
    {
        private string _auditoriaApi;

        public TipoDeGastoController(IConfiguration config) 
        {
            _auditoriaApi = config.GetValue<string>("URLApiAuditoria");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int tipoDeGastoId)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");

                string url = $"{_auditoriaApi}/{tipoDeGastoId}";

                HttpResponseMessage resp = AuxiliarClienteHttp.EnviarSolicitud(url, "GET", null, token);
                string body = AuxiliarClienteHttp.ObtenerBody(resp);

                if (!resp.IsSuccessStatusCode)
                {
                    ViewBag.Error = body;
                    return View();
                }

                var auditorias = JsonConvert.DeserializeObject<IEnumerable<AuditoriaDTO>>(body);
                ViewBag.Resultados = auditorias;

                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Error interno, intente mas tarde";
                return View();
               
            }
                   
        }
    }
   
}