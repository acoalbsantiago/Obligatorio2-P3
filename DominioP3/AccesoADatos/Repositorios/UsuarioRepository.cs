using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AccesoADatos.EF;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

namespace AccesoADatos.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ObligatorioContext _context;

        public UsuarioRepository(ObligatorioContext contexto) 
        {
            _context = contexto;
        }

        public void Add(Usuario value)
        {
            try
            {
                value.Validar();
                _context.Usuario.Add(value);
                _context.SaveChanges();
            }
            catch (UsuarioException)
            {
                    throw;
            
            }catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado", ex);
            }
           
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuario;
        }

        public Usuario Login(string email, string pass)
        {
            //foreach(Usuario usuario in _context.Usuario)
            //{
            //    if (usuario.Email.Correo == email)
            //    {
            //        if (usuario.Password == pass)
            //        {
            //            return usuario;
            //        }
            //        throw new UsuarioException("Nombre de usuario o contraseña incorrecta");
            //    }
            //}
            //throw new UsuarioException("Nombre de usuario o contraseña incorrecta");

            Usuario logueado = _context.Usuario.Where(
                user => user.Password == pass &&
                        user.Email.Correo == email
                ).FirstOrDefault();
            if(logueado == null)
            {
                throw new UsuarioException("Nombre de usuario o contraseña incorrecta");
            }
            return logueado;
        }
         
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> UsuariosSegunMontoDado(decimal monto)
        {
            return _context.Usuario
                                    .Include(u => u.Pagos.Where(p => p.MontoTotal > monto)) 
                                    .Where(u => u.Pagos.Any(p => p.MontoTotal > monto))       
                                    .ToList();
        }          
        
        public bool ExisteMail (string email)
        {
            return _context.Usuario.Any(user => user.Email.Correo == email);
        }
    }
}
