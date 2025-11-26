using clienteMVC.Auxiliar;
using clienteMVC.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Newtonsoft.Json;
using clienteMVC.Filters;


namespace clienteMVC.Controllers
{
    [LogueadoFilter]
    public class PagoController : Controller

    {
        private string _urlApi;
        
        public PagoController(IConfiguration config) 
        {
            _urlApi = config.GetValue<string>("URLApiContenidos");
        }

        // GET: PagoController
        //public ActionResult Index()
        //{
        //    IEnumerable<PagoDTO> pagos = new List<PagoDTO>();

        //    try
        //    {
        //        //string token = HttpContext.Session.GetString("token");
        //        string url = $"{_urlApi}/Pago";

        //        HttpResponseMessage respuesta = AuxiliarClienteHttp.EnviarSolicitud(url, "GET", null, null);

        //        string body = AuxiliarClienteHttp.ObtenerBody(respuesta);

        //        if (respuesta.IsSuccessStatusCode)
        //        {
        //            pagos = JsonConvert.DeserializeObject<IEnumerable<PagoDTO>>(body);
        //        }else
        //        {
        //           ViewBag.Mensaje = body;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        ViewBag.Mensaje = "Ocurrió un error inesperado. Intente de nuevo más tarde.";
        //    }

        //    return View(pagos);
        //}

        // GET: PagoController/Details/5
        public IActionResult Details(int id)
        {
            try
            {
                string url = $"{_urlApi}/Pago/{id}";
                string token = HttpContext.Session.GetString("token");

                HttpResponseMessage respuesta = AuxiliarClienteHttp.EnviarSolicitud(url, "GET", null, token);
                string body = AuxiliarClienteHttp.ObtenerBody(respuesta);

                if (!respuesta.IsSuccessStatusCode)
                {
                    ViewBag.Error = body;
                    return View("Index");
                }
                PagoDTO pago = JsonConvert.DeserializeObject<PagoDTO>(body);
                return View(pago);
            }
            catch (Exception)
            {

                ViewBag.Error = "Error interno, intente mas tarde";
                return View("Index");
            }
           
        }

        // GET: PagoController/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: PagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PagoDTO pago)
        {
            try
            {
                string url = $"{_urlApi}/Pago";
                string token = HttpContext.Session.GetString("token");

                HttpResponseMessage respuesta = AuxiliarClienteHttp.EnviarSolicitud(url, "POST", pago, token);

                string body = AuxiliarClienteHttp.ObtenerBody(respuesta);

                if (!respuesta.IsSuccessStatusCode)
                {
                    ViewBag.Error = body;
                    return View(pago);
                }

                PagoDTO pagoCreado = JsonConvert.DeserializeObject<PagoDTO>(body);
                return RedirectToAction("Details", new { id = pagoCreado.Id });
            }

            catch
            {
                ViewBag.Error = "Error interno, intente mas tarde";
                return View();
            }
        }
        [EmpYGerenteFilter]
        [HttpGet]
        public IActionResult MisPagos()
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                string url = $"{_urlApi}/Pago/PagosDelUsuario";
                HttpResponseMessage respuesta = AuxiliarClienteHttp.EnviarSolicitud(url, "GET", null, token);
                string body = AuxiliarClienteHttp.ObtenerBody(respuesta);

                if (!respuesta.IsSuccessStatusCode)
                {
                    ViewBag.Error = body;
                    return View();
                }

                IEnumerable<PagoDTO> pagos = JsonConvert.DeserializeObject<IEnumerable<PagoDTO>>(body);
                return View(pagos);
            }
            catch (Exception)
            {
                ViewBag.Error = "Error interno, intente mas tarde";
                return View();
            }          
        }
    }
}
