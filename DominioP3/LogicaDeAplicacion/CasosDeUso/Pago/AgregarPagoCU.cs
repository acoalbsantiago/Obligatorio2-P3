using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.Pago
{
    public class AgregarPagoCU : IAgregarPago
    {
        private IPagoRepository _repo;
        public AgregarPagoCU(IPagoRepository repo) 
        {
            _repo = repo;
        }
        public int AltaPago(PagoDTO nuevoPago, int idUsuario)
        {
            try
            {
                var pago = PagoMapper.FromDTO(nuevoPago, idUsuario);
                _repo.Add(pago);
                Console.WriteLine(pago.Id);
                return pago.Id;
            }
            catch (PagoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error al registrar el pago.", ex);
            }
        }            
    }
}

