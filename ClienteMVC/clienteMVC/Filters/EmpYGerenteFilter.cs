using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace clienteMVC.Filters
{
    public class EmpYGerenteFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("rol");

            if (string.IsNullOrWhiteSpace(rol) || (rol != "EMPLEADO" && rol != "GERENTE"))
            {
                context.Result = new RedirectToActionResult(
                    "Index",
                    "Home",
                    new { error = "Debe ser Empleado o gerente para acceder" }
                );
            }

            base.OnActionExecuting(context);
        }

    }
}
