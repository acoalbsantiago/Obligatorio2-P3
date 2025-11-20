using LogicaDeAplicacion.InterfacesCU.Auditoria;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.Auditoria
{
    public class ObtenerAuditoriaPorIdCU : IObtenerAuditoriaPorId
    {
        private IAuditoriaRepositorio _repo;
        public ObtenerAuditoriaPorIdCU(IAuditoriaRepositorio repo)
        {
            _repo = repo;
        }

        public IEnumerable<AuditoriaTipoDeGasto> IObtenerAuditoriaPorId(int TipoDeGastoId)
        {
            return _repo.AuditoriasSegunTipoDeGasto(TipoDeGastoId);
        }
    }

}
