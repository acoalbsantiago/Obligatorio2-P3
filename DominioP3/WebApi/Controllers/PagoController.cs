using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Pago;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private IObtenerPagoPorId _obtenerPagoPorId;
        private IObtenerPagosDadoAnioYmes _test;

        public PagoController (IObtenerPagoPorId obtenerPagoPorId, IObtenerPagosDadoAnioYmes test)
        {
            _obtenerPagoPorId = obtenerPagoPorId;
            _test = test;
        }

        // GET api/pagos/5
        //[HttpGet("{id}")]
        //public IActionResult GetPagoById(int id)
        //{
        //    try
        //    {
        //        var pago = _obtenerPagoPorId.ObtenerPagoPorId(id);

        //        if (pago == null)
        //            return NotFound(new { mensaje = "No se encontró un pago con el id especificado." });

        //        return Ok(pago);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { mensaje = "Error interno del servidor.", detalle = ex.Message });
        //    }
        //}
        [HttpGet("{mes}")]
        public IActionResult ObtenerPagosTest(int mes)
        {
            try
            {
                IEnumerable<PagoDTO> pagos = _test.ObtenerPagosPorMesYAño(mes, 2025);

                if (pagos == null)
                    return NotFound(new { mensaje = "No se encontró un pago con el id especificado." });

                return Ok(pagos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor.", detalle = ex.Message });
            }
        }
    }
}
    

