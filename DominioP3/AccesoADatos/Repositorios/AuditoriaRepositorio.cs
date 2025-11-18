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
    public class AuditoriaRepositorio : IAuditoriaRepositorio
    {
        private ObligatorioContext _context;

        public AuditoriaRepositorio(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(AuditoriaTipoDeGasto value)
        {
            _context.AuditoriaTipoDeGasto.Add(value);
            _context.SaveChanges();
        }

    }
}
