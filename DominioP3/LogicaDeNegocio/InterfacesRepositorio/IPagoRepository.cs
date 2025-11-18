using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.InterfacesRepositorio
{
    public interface IPagoRepository : IRepository<Pago>
    {
        public IEnumerable<Pago> ObtenerPagosPorAnioYmes(int mes, int año);
    }
}
