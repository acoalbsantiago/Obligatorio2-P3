using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.InterfacesRepositorio
{
    public interface ITipoDeGastoRepository : IRepository<TipoDeGasto>
    {
        public TipoDeGasto AddSecundario(TipoDeGasto tipo);
    }
}
