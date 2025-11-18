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
        public void AltaPago(PagoDTO nuevoPago, int idUsuario)
        {
            try
            {
                _repo.Add(PagoMapper.FromDTO(nuevoPago, idUsuario));
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

