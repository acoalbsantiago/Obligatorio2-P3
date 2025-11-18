using AccesoADatos.Repositorios;
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
    public class ObtenerPagosCU : IObtenerPagos
    {
        private IPagoRepository _repo;
        
        public ObtenerPagosCU(IPagoRepository repo) 
        {
            _repo = repo;
        }

        public IEnumerable<PagoDTO> ObtenerPagos()
        {
            List<PagoDTO> toReturn = new List<PagoDTO>();
            foreach (LogicaDeNegocio.Entidades.Pago tipo in _repo.GetAll())
            {
                toReturn.Add(PagoMapper.ToDTO(tipo));
            }
            return toReturn;
        }
    }
}
