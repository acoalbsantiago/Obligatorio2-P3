using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.Pago
{
    public class ObtenerPagosPorUsuarioCU : IObtenerPagosPorUsuario
    {

        private IPagoRepository _repo;

        public ObtenerPagosPorUsuarioCU(IPagoRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<PagoDTO> ObtenerPagosPorUsuario(int usuarioId)
        {
            IEnumerable<LogicaDeNegocio.Entidades.Pago> pagos = _repo.ObtenerPagosDeUsuario(usuarioId);

            return pagos.Select(pago => PagoMapper.ToDTO(pago)).ToList();
        }

    }
}
