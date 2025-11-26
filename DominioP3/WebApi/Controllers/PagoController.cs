using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PagoController : ControllerBase
    {
        private IObtenerPagoPorId _obtenerPagoPorId;
        private IAgregarPago _agregarPago;
        private IObtenerPagos _obtenerPagos;
        private IObtenerPagosPorUsuario _obtenerPagosPorUsuario;

        public PagoController (IObtenerPagoPorId obtenerPagoPorId, 
                               IAgregarPago agregarPago,
                               IObtenerPagos obtenerPagos,
                               IObtenerPagosPorUsuario pagosPorUsuario
        )
        {
           _obtenerPagoPorId = obtenerPagoPorId;
           _agregarPago = agregarPago;
           _obtenerPagos = obtenerPagos;
           _obtenerPagosPorUsuario = pagosPorUsuario;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PagoDTO>> ObtenerPagos()
        {
            return Ok(_obtenerPagos.ObtenerPagos());
        }

        [HttpGet("{id}", Name="PagoPorId")]
        public ActionResult GetPagoById(int id)
        {
            try
            {
                var pago = _obtenerPagoPorId.ObtenerPagoPorId(id);

                if (pago == null)
                    return NotFound(new { mensaje = "No se encontró un pago con el id especificado." });

                return Ok(pago);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        public ActionResult AltaPago([FromBody] PagoDTO? pago)
        {
            if (pago == null) return BadRequest("No se proporcionarion los datos para el alta");
            
            try
            {
                var claimId = User.FindFirst(ClaimTypes.NameIdentifier);
                if (claimId == null) return Unauthorized("Token inválido: no contiene el ID del usuario.");
                
                int userId = int.Parse(claimId.Value);
                int idPago = _agregarPago.AltaPago(pago, userId);
                pago.Id = idPago;

            }catch(PagoException pex) 
            { 
                return BadRequest(pex.Message);
            }
            catch(Exception)
            {
                return StatusCode(500, "Error interno en el servidor");
            }
            return CreatedAtRoute("PagoPorId", new { id = pago.Id }, pago);
        }

        [HttpGet("PagosDelUsuario")]
        [Authorize(Roles = "EMPLEADO,GERENTE")]
        public ActionResult<IEnumerable<PagoDTO>> ObtenerMisPagos()
        { 
            try
            {
                var claimId = User.FindFirst(ClaimTypes.NameIdentifier);

                if (claimId == null)
                    return Unauthorized("Token inválido: no contiene el ID del usuario.");

                int userId = int.Parse(claimId.Value);

                IEnumerable<PagoDTO> pagos = _obtenerPagosPorUsuario.ObtenerPagosPorUsuario(userId);

                if (pagos == null || !pagos.Any())
                    return NotFound("No hay pagos asociados al usuario.");

                return Ok(pagos);
            }
            catch (Exception)
            {               
                return StatusCode(500, "Error interno procesando la solicitud");
            }
        }
    }
}
    

