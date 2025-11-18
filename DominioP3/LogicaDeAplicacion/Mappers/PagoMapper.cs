using LogicaDeAplicacion.DTOs;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.Mappers
{
    public class PagoMapper
    {
        public static Pago FromDTO (PagoDTO dto, int usuarioId)
        {        

            if (dto.TipoDePago == TipoDePago.Unico)
            {
                return new PagoUnico
                {
                    Id = dto.Id,
                    MetodoDePago = dto.MetodoDePago,
                    Descripcion = dto.Descripcion,
                    MontoTotal = dto.MontoTotal,
                    TipoDeGastoId = dto.TipoDeGastoId,
                    UsuarioId = usuarioId,
                    FechaPago = dto.FechaPago,
                    NumFactura = dto.NumFactura
            };
              
            }
            else if (dto.TipoDePago == TipoDePago.Recurrente)
            {
                if (dto.MontoTotal == null || dto.FechaDesde == null || dto.FechaHasta == null)
                    throw new ArgumentException("Los campos MontoMensual, FechaDesde y FechaHasta son obligatorios para pagos recurrentes.");

                return new PagoRecurrente(
                    dto.MontoTotal,
                    dto.FechaDesde,
                    dto.FechaHasta)
                {
                    Id = dto.Id,
                    MetodoDePago = dto.MetodoDePago,
                    Descripcion = dto.Descripcion,
                    TipoDeGastoId = dto.TipoDeGastoId,
                    UsuarioId = usuarioId
                };
            }
            else
            {
                throw new ArgumentException("Tipo de pago no soportado");
            }

        }

        public static PagoDTO ToDTO(Pago entity)
        {
            PagoDTO dto = new PagoDTO
            {
                Id = entity.Id,
                MetodoDePago = entity.MetodoDePago,
                Descripcion = entity.Descripcion,
                MontoTotal = entity.MontoTotal,
                UsuarioId = entity.UsuarioId,
                TipoDeGastoId = entity.TipoDeGastoId,
                TipoDeGasto = TipoDeGastoMapper.ToDTO(entity.TipoDeGasto),
                Usuario = UsuarioMapper.ToDTO(entity.Usuario)
            };

            if (entity is PagoUnico pu)
            {
                dto.TipoDePago = TipoDePago.Unico;
                dto.FechaPago = pu.FechaPago;
                dto.NumFactura = pu.NumFactura;
                dto.FechaDesde = null;
                dto.FechaHasta = null;
            }
            else if (entity is PagoRecurrente pr)
            {
                dto.TipoDePago = TipoDePago.Recurrente;
                dto.FechaDesde = pr.FechaDesde;
                dto.FechaHasta = pr.FechaHasta;
                dto.FechaPago = null;
                dto.NumFactura = null;
            }

            return dto;
        }

        public static PagoDTO ToDTO(Pago entity, int mes, int año)
        {
            var dto = ToDTO(entity); // reaprovechamos el anterior

            dto.SaldoPendiente = entity.CalcularSaldoPendiente(mes, año);
            return dto;
        }
    }
}

