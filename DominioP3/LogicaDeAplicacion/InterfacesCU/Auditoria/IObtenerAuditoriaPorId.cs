using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.InterfacesCU.Auditoria
{
    public interface IObtenerAuditoriaPorId
    {
        public IEnumerable< AuditoriaTipoDeGasto> IObtenerAuditoriaPorId(int TipoDeGastoId);
    }
}
