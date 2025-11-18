using System.Diagnostics;
using clienteMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace clienteMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public IActionResult Test(int id)
        {
            using var http = new HttpClient();

            string url = $"https://localhost:7130/api/Pago/{id}";

            // Ejecutar la llamada sin async/await
            var response = http.GetAsync(url).Result;

            var content = response.Content.ReadAsStringAsync().Result;

            return Content(
                $"Status: {response.StatusCode}\n\nRespuesta:\n{content}"
            );
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
