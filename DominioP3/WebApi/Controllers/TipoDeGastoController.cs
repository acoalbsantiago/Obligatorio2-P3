using LogicaDeAplicacion.InterfacesCU.Auditoria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMINISTRADOR")]
    public class TipoDeGastoController : ControllerBase
    {
        private IObtenerAuditoriaPorId _auditorias;
        public TipoDeGastoController(IObtenerAuditoriaPorId auditorias)
        {
            _auditorias = auditorias;
        }

        [HttpGet("AuditoriaSegunTipoDeGasto/{id}")]
        public IActionResult ObtenerAuditorias(int id)
        {
            try
            {
                return Ok(_auditorias.IObtenerAuditoriaPorId(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }           
        }
    }
}


