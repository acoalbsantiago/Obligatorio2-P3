using AccesoADatos.EF;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Repositorios
{
    public class EquipoRepository : IEquipoRepository
    {
        private ObligatorioContext _context;

        public EquipoRepository(ObligatorioContext context)
        {
            _context = context;
        }


        public void Add(Equipo value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> EquiposSegunMontoDePagoUnico(decimal monto)
        {
            IEnumerable< Equipo> equipos = _context.pagos
                                           .OfType<PagoUnico>()
                                           .Where(p => p.MontoTotal > monto)
                                           .Select(p => p.Usuario.Equipo)
                                           .Distinct()
                                           .OrderByDescending(e => e.Nombre)
                                           .ToList();
            return equipos;
        }

        public Equipo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> GetAll()
        {
            return _context.equipos;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Equipo value)
        {
            _context.SaveChanges();
        }
    }
}
