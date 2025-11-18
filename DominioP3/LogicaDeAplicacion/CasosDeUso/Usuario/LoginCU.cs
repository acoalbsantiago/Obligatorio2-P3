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
    public class LoginCU : ILogin
    {
        private IUsuarioRepository _repo;
        
        public LoginCU(IUsuarioRepository usuarioRepository)
        {
             _repo = usuarioRepository;
        }
        public UsuarioDTO Login(string email, string password)
        {
            return UsuarioMapper.ToDTO( _repo.Login(email, password));
        }
    }
}
