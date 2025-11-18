using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Usuario;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.Usuario
{
    public class ObtenerUsuariosSegunMontoCU : IObtenerUsuariosSegunMonto
    {
        private IUsuarioRepository _repo;

        public ObtenerUsuariosSegunMontoCU(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<UsuarioDTO> ObtenerUsuariosSegunMonto(decimal monto)
        {
            return _repo.UsuariosSegunMontoDado(monto)
                        .Select(user => UsuarioMapper.ToDTO(user)).ToList();
        }
    }
}
