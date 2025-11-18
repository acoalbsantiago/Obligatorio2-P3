using LogicaDeAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.InterfacesCU.Usuario
{
    public interface IObtenerUsuariosSegunMonto
    {
        public IEnumerable<UsuarioDTO> ObtenerUsuariosSegunMonto(decimal monto);
    }
}
