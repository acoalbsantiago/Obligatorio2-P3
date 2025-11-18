using LogicaDeAplicacion.DTOs;
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
    public class EditarTipoDeGastoCU : IEditarTipoDeGasto
    {
        private ITipoDeGastoRepository _repo;
        private IRegistrarCambioAuditoria _auditoria;

        public EditarTipoDeGastoCU(ITipoDeGastoRepository repo, 
                                    IRegistrarCambioAuditoria auditoria)
        {
            _repo = repo;
            _auditoria = auditoria;
        }
        public void EditarTipoDeGasto(TipoDeGastoDTO tipoDTO, int usuarioId)
        {
           LogicaDeNegocio.Entidades.TipoDeGasto tipo = _repo.FindById(tipoDTO.Id);
           
            tipo.Nombre = tipoDTO.Nombre;
            tipo.Descripcion = tipoDTO.Descripcion;

            _repo.Update(tipo);
            _auditoria.RegistrarCambioAuditoria(tipoDTO.Id, "Modificacion", usuarioId);

        }
    }
}
