using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Equipo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EquipoController : ControllerBase
    {
        private IObtenerEquiposSegunMontoDePagoUnico _obtenerEquiposSegunMonto;

        public EquipoController(IObtenerEquiposSegunMontoDePagoUnico obtenerEquiposSegunMonto) 
        {
            _obtenerEquiposSegunMonto = obtenerEquiposSegunMonto;
        }

        [ProducesResponseType(typeof(IEnumerable<EquipoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("ConPagosMayores/{monto}")]
        [Authorize(Roles = "GERENTE")]
        public IActionResult ObtenerEquiposPorMontoDePagoUnico (decimal monto)
        {
            if (monto < 0) return BadRequest("El monto tiene que ser positivo");
            try
            {
                return Ok(_obtenerEquiposSegunMonto.ObtenerEquiposSegunMontoDePagoUnico(monto));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
