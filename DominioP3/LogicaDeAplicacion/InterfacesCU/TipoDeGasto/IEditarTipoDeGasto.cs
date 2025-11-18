using LogicaDeAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.InterfacesCU.TipoDeGasto
{
    public interface IEditarTipoDeGasto
    {
        public void EditarTipoDeGasto(TipoDeGastoDTO tipoDTO, int usuarioId);
    }
}
