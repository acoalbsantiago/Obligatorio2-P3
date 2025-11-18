using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    [Table("TipoDeGasto")]
    public class TipoDeGasto : IValidable
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public TipoDeGasto() { }
        
        public TipoDeGasto(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                    throw new TipoDeGastoException("El nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(Descripcion))
                    throw new TipoDeGastoException("La descripcion no puede estar vacia.");
        }
    }
}
