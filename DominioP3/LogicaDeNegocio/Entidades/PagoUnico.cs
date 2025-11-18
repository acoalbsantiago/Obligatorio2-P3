using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class PagoUnico : Pago
    {
        public DateTime? FechaPago { get; set; }
        public int? NumFactura { get; set; }

        public PagoUnico(): base() { }

        public override decimal? CalcularSaldoPendiente(int mes, int anio)
        {
            return 0;
        }

        public override void Validar()
        {
            if (string.IsNullOrWhiteSpace(Descripcion))
                throw new PagoException("Debe ingresar una descripción.");
            if (MontoTotal <= 0)
                throw new PagoException("El monto debe ser mayor que cero.");

            if (FechaPago > DateTime.Now)
                throw new PagoException("Debe ingresar una fecha anterior o igual a hoy.");
        }

        public override bool PerteneceAlMes(int mes, int anio)
        {
            if (!FechaPago.HasValue)
                return false;

            return FechaPago.Value.Month == mes && FechaPago.Value.Year == anio;
        }
    }
}
