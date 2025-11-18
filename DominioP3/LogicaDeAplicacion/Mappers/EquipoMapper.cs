using LogicaDeAplicacion.DTOs;
using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.Mappers
{
    public class EquipoMapper
    {
        public static EquipoDTO ToDTO(Equipo equipo)
        {
            if (equipo == null)
                return null;

            return new EquipoDTO
            {
                Id = equipo.Id,
                Nombre = equipo.Nombre
            };
        }
        public static Equipo FromDTO(EquipoDTO dto)
        {
            if (dto == null)
                return null;

            return new Equipo
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }
    }
}
