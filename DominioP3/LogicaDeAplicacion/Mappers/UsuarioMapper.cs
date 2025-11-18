using LogicaDeAplicacion.DTOs;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Enums;
using LogicaDeNegocio.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaDeAplicacion.Mappers
{
    public class UsuarioMapper
    {
        public static Usuario FromDTO(UsuarioDTO usuarioDTO)
        {
            RolUsuario rol = Enum.Parse<RolUsuario>(usuarioDTO.Rol);
            return new Usuario(usuarioDTO.Nombre, usuarioDTO.Apellido, usuarioDTO.Password, rol, usuarioDTO.EquipoId);
        }

        public static UsuarioDTO ToDTO(Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Password = usuario.Password,
                Rol = usuario.Rol.ToString(),
                EquipoId = usuario.EquipoId,
                Email = usuario.Email
            };
        }

    }
}
    