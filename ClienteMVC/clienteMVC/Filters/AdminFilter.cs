using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace clienteMVC.Filters
{
    public class AdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("rol");

            // No logueado
            if (rol == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
                return;
            }

            // Logueado pero sin rol
            if (rol != "ADMINISTRADOR")
            {
                context.Result = new RedirectToActionResult(
                    "Index",
                    "Home",
                    new { error = "Debe ser Administrador para acceder a esta sección" }
                );
                return;
            }
        }
    }
}
