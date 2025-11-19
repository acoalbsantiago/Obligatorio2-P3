using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private IObtenerPagoPorId _obtenerPagoPorId;
        private IAgregarPago _agregarPago;
        private IObtenerPagos _obtenerPagos;

        public PagoController (IObtenerPagoPorId obtenerPagoPorId, 
                               IAgregarPago agregarPago,
                               IObtenerPagos obtenerPagos
        )
        {
           _obtenerPagoPorId = obtenerPagoPorId;
           _agregarPago = agregarPago;
           _obtenerPagos = obtenerPagos;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PagoDTO>> ObtenerPagos()
        {
            return Ok(_obtenerPagos.ObtenerPagos());
        }

        //GET api/pagos/5
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
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor.", detalle = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult AltaPago([FromBody] PagoDTO? pago)
        {
            if (pago == null) return BadRequest("No se proporcionarion los datos para el alta");
            
            try
            {
                _agregarPago.AltaPago(pago, 1);
               
            }catch(PagoException pex) 
            { 
                return BadRequest(pex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

            return CreatedAtRoute("PagoPorId", new { id = pago.Id }, pago);
        }

    }
}
    

