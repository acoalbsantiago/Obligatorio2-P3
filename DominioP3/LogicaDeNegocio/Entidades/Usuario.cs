using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Enums;
using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.Interfaces;
using LogicaDeNegocio.ValueObjets;
using Microsoft.EntityFrameworkCore;

namespace LogicaDeNegocio.Entidades
{
    //[Index(nameof(Email), IsUnique = true)]
    public class Usuario : IValidable
    {
        public int Id { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string Apellido { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set;}
        public Email Email { get; set; }
        public RolUsuario Rol { get; set; }
        public List<Pago> Pagos { get; set; } = new List<Pago>();
        public Equipo Equipo { get; set; }
        [ForeignKey("Equipo")]
        public int EquipoId { get; set; }

        public Usuario() { }
        public Usuario (string nombre, string apellido, string pass, RolUsuario rol, int equipo) 
        {
           Nombre = nombre;
           Apellido = apellido;
           Password = pass;
           Rol = rol;
           Email = Email.Crear(nombre, apellido);
           EquipoId = equipo;
           Validar();
        }

        public void RegenerarCorreo()
        {
            Email = Email.CrearSecundario(Nombre, Apellido);
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new UsuarioException("El nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(Apellido))
                throw new UsuarioException("El apellido no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(Password))
                throw new UsuarioException("Debe especificar una contraseña.");
        }
    }
}
