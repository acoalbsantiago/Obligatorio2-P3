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
    public class ObtenerEquiposSegunMontoDePagoUnicoCU : IObtenerEquiposSegunMontoDePagoUnico
    {
        private IEquipoRepository _repo;

        public ObtenerEquiposSegunMontoDePagoUnicoCU(IEquipoRepository repo) 
        {
            _repo = repo;
        }

        public IEnumerable<EquipoDTO> ObtenerEquiposSegunMontoDePagoUnico(decimal monto)
        {
            IEnumerable<LogicaDeNegocio.Entidades.Equipo> aRetornar = _repo.EquiposSegunMontoDePagoUnico(monto);

            return aRetornar.Select(equipo => EquipoMapper.ToDTO(equipo)).ToList();
        }
    }
}
