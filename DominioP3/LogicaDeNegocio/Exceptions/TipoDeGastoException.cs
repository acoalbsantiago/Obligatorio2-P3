using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Exceptions
{
    public class TipoDeGastoException : Exception
    {
        public TipoDeGastoException() { }
        public TipoDeGastoException(string mensaje)
        : base(mensaje) { }
        public TipoDeGastoException(string mensaje, Exception ex)
        : base(mensaje, ex) { }

    }
}
