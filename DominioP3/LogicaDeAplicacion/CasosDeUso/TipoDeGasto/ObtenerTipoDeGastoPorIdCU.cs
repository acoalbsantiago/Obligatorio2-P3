using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.TipoDeGasto
{
    public class ObtenerTipoDeGastoPorIdCU: IObtenerTipoDeGastoPorId
    {
        private ITipoDeGastoRepository _repo;

        public ObtenerTipoDeGastoPorIdCU(ITipoDeGastoRepository repo) 
        {
            _repo = repo;
        }

        public TipoDeGastoDTO ObtenerTipoDeGastoPorId(int id)
        {
            return TipoDeGastoMapper.ToDTO( _repo.FindById(id));
        }
    }
}
