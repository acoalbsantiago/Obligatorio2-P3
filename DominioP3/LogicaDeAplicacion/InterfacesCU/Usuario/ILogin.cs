using LogicaDeAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.InterfacesCU.Usuario
{
    public interface ILogin
    {
        public UsuarioDTO Login(string email, string password);
    }
}
