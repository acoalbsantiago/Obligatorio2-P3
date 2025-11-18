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
    public class ObtenerPagosSegunAnioYmesCU : IObtenerPagosDadoAnioYmes
    {
        private IPagoRepository _repo;
        public ObtenerPagosSegunAnioYmesCU(IPagoRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<PagoDTO> ObtenerPagosPorMesYAño(int mes, int anio)
        {
        
            IEnumerable<LogicaDeNegocio.Entidades.Pago> pagos = _repo.ObtenerPagosPorAnioYmes(mes, anio);

            return pagos.Select(p => PagoMapper.ToDTO(p, mes, anio)).ToList();
        }
    }
}
