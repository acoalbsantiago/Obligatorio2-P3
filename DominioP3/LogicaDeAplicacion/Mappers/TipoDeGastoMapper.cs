using LogicaDeAplicacion.DTOs;
using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.Mappers
{
    public class TipoDeGastoMapper
    {
        public static TipoDeGasto FromDTO(TipoDeGastoDTO tipoDTO)
        {
            return new TipoDeGasto
            { 
                Nombre = tipoDTO.Nombre,
                Descripcion = tipoDTO.Descripcion,
                Id = tipoDTO.Id
            };
        }

        public static TipoDeGastoDTO ToDTO(TipoDeGasto tipo)
        {
            return new TipoDeGastoDTO
            {
                Nombre = tipo.Nombre,
                Descripcion = tipo.Descripcion,
                Id = tipo.Id
            };
        }

    }
}
