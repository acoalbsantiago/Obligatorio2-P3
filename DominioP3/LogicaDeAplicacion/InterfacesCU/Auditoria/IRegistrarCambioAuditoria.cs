using LogicaDeAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.InterfacesCU.Auditoria
{
    public interface IRegistrarCambioAuditoria
    {
        public void RegistrarCambioAuditoria(int tipoDeGastoId, string accion, int usuarioId);
    }

}
