using System.Net.Http.Headers;

namespace clienteMVC.Auxiliar
{
    public static class AuxiliarClienteHttp
    {
        public static HttpResponseMessage EnviarSolicitud(string url, string verbo, object obj = null, string token = null)
        {
            HttpClient cliente = new HttpClient();
            Task<HttpResponseMessage> tarea = null;
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            if (verbo == "GET")
            {
                tarea = cliente.GetAsync(url);
            }
            else if (verbo == "POST")
            {
                tarea = cliente.PostAsJsonAsync(url, obj);
            }
            else if (verbo == "DELETE")
            {
                tarea = cliente.DeleteAsync(url);
            }
            else if (verbo == "PUT")
            {
                tarea = cliente.PutAsJsonAsync(url, obj);
            }

            tarea.Wait();
            return tarea.Result;
        }

        public static string ObtenerBody(HttpResponseMessage respuesta)
        {
            var tarea = respuesta.Content.ReadAsStringAsync();
            tarea.Wait();
            return tarea.Result;
        }
    }
}
