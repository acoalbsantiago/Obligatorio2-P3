using clienteMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace clienteMVC.DTOs
{
    public class PagoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El metodo de pago es obligatorio.")]
        public MetodoDePago MetodoDePago { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        public string Descripcion { get; set; }
        public TipoDeGastoDTO? TipoDeGasto { get; set; }
        [Required(ErrorMessage = "El tipo de gasto es obligatorio.")]
        public int TipoDeGastoId { get; set; }
        public UsuarioDTO? Usuario { get; set; }
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "El monto es obligatorio.")]
        public decimal? MontoTotal { get; set; }

        public TipoDePago TipoDePago { get; set; }

        //si pago es recurrente
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime? FechaDesde { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime? FechaHasta { get; set; }

        //si es pago unico
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime? FechaPago { get; set; }
        [Required(ErrorMessage = "El Nro de factura es obligatoria.")]
        public int? NumFactura { get; set; }
        public decimal? SaldoPendiente { get; set; }

        public PagoDTO() { }
    }
}
