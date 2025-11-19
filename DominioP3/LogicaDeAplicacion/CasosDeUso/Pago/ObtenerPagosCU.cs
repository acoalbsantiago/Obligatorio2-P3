using AccesoADatos.Repositorios;
using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            IEnumerable<LogicaDeNegocio.Entidades.Pago> toReturn = _repo.GetAll();
            return toReturn.Select(cont => PagoMapper.ToDTO(cont));
        }
    }
}
