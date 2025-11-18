using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Equipo : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>(); 

        public Equipo() { }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new EquipoException("El nombre no puede estar vacío.");
        }
    }
}
