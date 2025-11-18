using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.DTOs
{
    public class TipoDeGastoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Nombre Invalido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatorio.")]
        [DisplayName("Tipo de gasto descrip")]
        public string Descripcion { get; set; }
    }
}
