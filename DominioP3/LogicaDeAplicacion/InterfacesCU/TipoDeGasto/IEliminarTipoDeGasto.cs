using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.InterfacesCU.TipoDeGasto
{
    public interface IEliminarTipoDeGasto
    {
        public void EliminarTipoDeGasto(int id, int usuarioId); 
    }
}
