using AccesoADatos.Repositorios;
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
    public class ObtenerUsuariosCU : IObtenerUsuarios
    {
        private IUsuarioRepository _repo;
        public ObtenerUsuariosCU(IUsuarioRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<UsuarioDTO> ObtenerUsuarios()
        {
            IEnumerable<LogicaDeNegocio.Entidades.Usuario> toReturn = _repo.GetAll();
            return toReturn.Select(usuario => UsuarioMapper.ToDTO(usuario));
        }
    }
}
