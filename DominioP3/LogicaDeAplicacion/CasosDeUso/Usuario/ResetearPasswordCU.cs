using LogicaDeAplicacion.InterfacesCU.Usuario;
using LogicaDeAplicacion.Utilidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.Usuario
{
    public class ResetearPasswordCU : IResetearPassword
    {
        private IUsuarioRepository _repo;
        public ResetearPasswordCU(IUsuarioRepository repo) { _repo = repo; }
        public string ResetearPassword(int idUsuario)
        {
            try
            {

               LogicaDeNegocio.Entidades.Usuario user = _repo.FindById(idUsuario);
                
               if (user == null) throw new UsuarioException("No se encontro usurio");
               
                user.Password = PasswordGenerator.Generar();
                _repo.Update(user);
                return user.Password;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al reseter contraseña", ex);
            }
        }
    }
}
