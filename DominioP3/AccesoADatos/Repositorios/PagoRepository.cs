using AccesoADatos.EF;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Repositorios
{
    public class PagoRepository : IPagoRepository
    {
        private ObligatorioContext _context;

        public PagoRepository(ObligatorioContext context)
        {
            _context = context;
        }
        public void Add(Pago value)
        {
            try
            {
                value.Validar();
                _context.pagos.Add(value);
                _context.SaveChanges();
            }
            catch (PagoException pe)
            {
                throw;

            }catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado", ex);
            }
            
        }

        public Pago FindById(int id)
        {
            Pago pago = _context.pagos
                         .Include(p => p.Usuario)
                        .Where(p => p.Id == id)
                        .FirstOrDefault();
                        /*FirstOrDefault(t => t.Id == id)*/;

            if (pago == null)
                throw new TipoDeGastoException("Tipo de gasto no encontrado.");

            return pago;
        }

        public IEnumerable<Pago> GetAll()
        {
            return _context.pagos;
        }

        public IEnumerable<Pago> ObtenerPagosPorAnioYmes(int mes, int anio)
        {

            var pagos = _context.pagos
                        .Include(p => p.Usuario)
                        .Include(p => p.TipoDeGasto)
                        .ToList();

            return pagos.Where(p => p.PerteneceAlMes(mes, anio));
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pago value)
        {
            throw new NotImplementedException();
        }
    }
}
