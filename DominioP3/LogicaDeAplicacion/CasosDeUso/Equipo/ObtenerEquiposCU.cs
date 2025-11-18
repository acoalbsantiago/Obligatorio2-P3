using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Equipo;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.Equipo
{
    public class ObtenerEquiposCU : IObtenerEquipos
    {
        private IEquipoRepository _repo;

        public ObtenerEquiposCU(IEquipoRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<EquipoDTO> ObtenerEquipos()
        {
            List<EquipoDTO> toReturn = new List<EquipoDTO>();
            foreach (LogicaDeNegocio.Entidades.Equipo equipo in _repo.GetAll())
            {
                toReturn.Add(EquipoMapper.ToDTO(equipo));
            }
            return toReturn;
        }
    }
}
