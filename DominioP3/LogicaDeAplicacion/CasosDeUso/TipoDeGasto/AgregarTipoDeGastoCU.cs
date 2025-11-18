using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Auditoria;
using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.TipoDeGasto
{
    public class AgregarTipoDeGastoCU : IAgregarTipoDeGasto
    {
        private ITipoDeGastoRepository _repo;
        private IRegistrarCambioAuditoria _auditoria;
        public AgregarTipoDeGastoCU(ITipoDeGastoRepository repo,
                                    IRegistrarCambioAuditoria auditoria)
        {
            _repo = repo;
            _auditoria = auditoria;
        }
        public void AgregarTipoDeGasto(TipoDeGastoDTO tipoDeGasto,int usuarioId)
        {
            var nuevoTipo = _repo.AddSecundario(TipoDeGastoMapper.FromDTO(tipoDeGasto));
            _auditoria.RegistrarCambioAuditoria(nuevoTipo.Id, "Agregar", usuarioId);
        }
    }
}
