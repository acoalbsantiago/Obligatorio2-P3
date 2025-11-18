using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.InterfacesRepositorio;
using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;

namespace LogicaDeAplicacion.CasosDeUso.TipoDeGasto
{
    public class ObtenerTipoDeGastoCU : IObtenerTipoDeGasto
    {
        private ITipoDeGastoRepository _repo;
        
        public ObtenerTipoDeGastoCU(ITipoDeGastoRepository repo) 
        { 
            _repo = repo; 
        }

        public IEnumerable<TipoDeGastoDTO> ObtenerTipoDeGasto()
        {
            return _repo.GetAll()
                 .Select(tipo => TipoDeGastoMapper.ToDTO(tipo))
                 .ToList();
        }
    }
}
