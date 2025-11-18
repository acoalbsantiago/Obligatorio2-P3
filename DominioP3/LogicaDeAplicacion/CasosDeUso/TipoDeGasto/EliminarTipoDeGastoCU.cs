using LogicaDeAplicacion.InterfacesCU.Auditoria;
using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.TipoDeGasto
{
    public class EliminarTipoDeGastoCU: IEliminarTipoDeGasto
    {
        private ITipoDeGastoRepository _repo;
        private IRegistrarCambioAuditoria _auditoria;
        public EliminarTipoDeGastoCU( ITipoDeGastoRepository tipoDeGastoRepository, 
                                      IRegistrarCambioAuditoria registrarCambioAuditoria) 
        {
            _repo = tipoDeGastoRepository;
            _auditoria = registrarCambioAuditoria;
        }

        public void EliminarTipoDeGasto(int id, int usuarioId)
        {
            try
            {
                _repo.Remove(id);
                _auditoria.RegistrarCambioAuditoria(id, "Eliminar", usuarioId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
