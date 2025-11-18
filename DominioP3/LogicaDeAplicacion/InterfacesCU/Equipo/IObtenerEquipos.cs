using LogicaDeAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.InterfacesCU.Equipo
{
    public interface IObtenerEquipos
    {
        public IEnumerable<EquipoDTO> ObtenerEquipos();
    }
}
