using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.DTOs
{
    public class PagoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El metodo de pago es obligatorio.")]
        public MetodoDePago MetodoDePago { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El tipo de pago es obligatorio.")]
        public TipoDeGastoDTO? TipoDeGasto { get; set; }
        public int TipoDeGastoId { get; set; }
        public UsuarioDTO? Usuario { get; set; }
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "El monto es obligatorio.")]
        public decimal? MontoTotal { get; set; }

        public TipoDePago TipoDePago { get; set; }

        //si pago es recurrente
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }

        //si es pago unico
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime? FechaPago { get; set; }
        public int? NumFactura { get; set; }
        public decimal? SaldoPendiente { get; set; }


        public PagoDTO() { }
    }
}
