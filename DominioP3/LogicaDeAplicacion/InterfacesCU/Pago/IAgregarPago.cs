using LogicaDeAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.InterfacesCU.Pago
{
    public interface IAgregarPago
    {
        public void AltaPago(PagoDTO nuevoPago, int usuarioLogueado);
    }
}
