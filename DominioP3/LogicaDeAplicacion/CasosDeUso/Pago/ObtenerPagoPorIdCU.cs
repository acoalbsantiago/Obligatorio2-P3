using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.Pago
{
    public class ObtenerPagoPorIdCU : IObtenerPagoPorId
    {
        private IPagoRepository _repo;

        public ObtenerPagoPorIdCU(IPagoRepository repo) 
        {
            _repo = repo;
        }

        public PagoDTO ObtenerPagoPorId(int id)
        {
            return PagoMapper.ToDTO(_repo.FindById(id));
        }
    }
}
