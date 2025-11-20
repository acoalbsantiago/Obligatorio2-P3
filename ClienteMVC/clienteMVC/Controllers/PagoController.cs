using clienteMVC.Auxiliar;
using clienteMVC.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Newtonsoft.Json;


namespace clienteMVC.Controllers
{
    public class PagoController : Controller

    {
        private string _urlApi;
        
        public PagoController(IConfiguration config) 
        {
            _urlApi = config.GetValue<string>("URLApiContenidos");
        }

        // GET: PagoController
        public ActionResult Index()
        {
            IEnumerable<PagoDTO> pagos = new List<PagoDTO>();

            try
            {
                //string token = HttpContext.Session.GetString("token");
                string url = $"{_urlApi}/Pago";

                HttpResponseMessage respuesta = AuxiliarClienteHttp.EnviarSolicitud(url, "GET", null, null);

                string body = AuxiliarClienteHttp.ObtenerBody(respuesta);

                if (respuesta.IsSuccessStatusCode)
                {
                    pagos = JsonConvert.DeserializeObject<IEnumerable<PagoDTO>>(body);
                }else
                {
                   ViewBag.Mensaje = body;
                }
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado. Intente de nuevo más tarde.";
            }

            return View(pagos);
        }

        // GET: PagoController/Details/5
        public IActionResult Details(int id)
        {
            string url = $"{_urlApi}/Pago/{id}";
            string token = HttpContext.Session.GetString("token");
            
            var response = AuxiliarClienteHttp.EnviarSolicitud(url, "GET", null, token);
            var body = AuxiliarClienteHttp.ObtenerBody(response);

            if (!response.IsSuccessStatusCode){
                ViewBag.Error = body;
                return View("Index");
            }
            PagoDTO pago = JsonConvert.DeserializeObject<PagoDTO>(body);
            return View(pago);
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

                if (respuesta.IsSuccessStatusCode)
                {
                    var pagoCreado = JsonConvert.DeserializeObject<PagoDTO>(body);
                    return RedirectToAction("Details", new { id = pagoCreado.Id });
                }
                else
                {
                    ViewBag.Mensaje = body; 
                    return View(pago);      
                }
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado. Intente de nuevo más tarde.";
                return View(pago);
            }
        }

        // GET: PagoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PagoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PagoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PagoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
