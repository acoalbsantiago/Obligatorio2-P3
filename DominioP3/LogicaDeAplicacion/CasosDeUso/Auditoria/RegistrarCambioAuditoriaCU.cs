using AccesoADatos.Repositorios;
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
    public class RegistrarCambioAuditoriaCU : IRegistrarCambioAuditoria
    {
        private IAuditoriaRepositorio _repo;
        public RegistrarCambioAuditoriaCU(IAuditoriaRepositorio repo)
        {
            _repo = repo;
        }

        public void RegistrarCambioAuditoria(int tipoDeGastoId, string accion, int usuarioId)
        {
            AuditoriaTipoDeGasto registro = new AuditoriaTipoDeGasto
            {
                TipoDeGastoId = tipoDeGastoId,
                Accion = accion,
                Fecha = DateTime.Now,
                UsuarioId = usuarioId
            };
            
            _repo.Add(registro);
        }

    }
}
