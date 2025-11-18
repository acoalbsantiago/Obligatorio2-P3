using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class AuditoriaTipoDeGasto
    {
        public int Id { get; set; }

        public int TipoDeGastoId { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        //public string? NombreUsuario { get; set; }

        public AuditoriaTipoDeGasto() { }
    }
}
