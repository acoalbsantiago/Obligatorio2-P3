using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Entidades;

namespace LogicaDeNegocio.InterfacesRepositorio
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        public IEnumerable<Usuario> UsuariosSegunMontoDado (decimal monto);
        public Usuario Login(string pass, string email);
        bool ExisteMail(string correo);
    }
}
