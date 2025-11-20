using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Equipo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private IObtenerEquiposSegunMontoDePagoUnico _obtenerEquiposSegunMonto;

        public EquipoController(IObtenerEquiposSegunMontoDePagoUnico obtenerEquiposSegunMonto) 
        {
            _obtenerEquiposSegunMonto = obtenerEquiposSegunMonto;
        }

        [HttpGet("ConPagosMayores/{monto}")]
        //[Authorize(Roles = "GERENTE")]
        public IActionResult ObtenerEquiposPorMontoDePagoUnico (decimal monto)
        {
            if (monto < 0) return BadRequest("El monto tiene que ser positivo");
            try
            {
                return Ok(_obtenerEquiposSegunMonto.ObtenerEquiposSegunMontoDePagoUnico(monto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
