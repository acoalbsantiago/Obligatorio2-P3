using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class PagoRecurrente : Pago
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public decimal? MontoMensual { get; set; }

        public PagoRecurrente(): base () { }

        public PagoRecurrente(decimal? montoMensual, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            MontoMensual = montoMensual;
            FechaDesde = fechaDesde;
            FechaHasta = fechaHasta;
            MontoTotal = CalcularMontoTotalPeriodo();
        }

        public int? CalcularCantidadDeMeses()
        {
            return ((FechaHasta?.Year - FechaDesde?.Year) * 12)
                 + (FechaHasta?.Month - FechaDesde?.Month);
        }

        public decimal? CalcularMontoTotalPeriodo()
        {
            return MontoMensual * CalcularCantidadDeMeses();
        }

        //public override decimal? CalcularSaldoPendiente(int mes, int anio)
        //{
        //    if (FechaDesde is null || FechaHasta is null)
        //        return 0;

        //    var periodo = new DateTime(anio, mes, 1);

        //    if (periodo < FechaDesde || periodo > FechaHasta)
        //        return 0;

        //    int mesesRestantes = ((FechaHasta.Value.Year - anio) * 12) + (FechaHasta.Value.Month - mes);
        //    return mesesRestantes > 0 ? mesesRestantes * MontoMensual : 0;
        //}

        public override void Validar()
        {
            if (string.IsNullOrWhiteSpace(Descripcion))
                throw new PagoException("Debe ingresar una descripción.");

            if (TipoDeGastoId <= 0)
                throw new PagoException("Debe seleccionar un tipo de gasto válido.");

            if (FechaDesde > FechaHasta)
                throw new PagoException("La fecha de inicio no puede ser posterior a la fecha de fin.");

            if (MontoMensual <= 0)
                throw new PagoException("El monto mensual debe ser mayor que cero.");
        }

        public override decimal? CalcularSaldoPendiente(int mes, int anio)
        {
            if (FechaDesde == null || FechaHasta == null || MontoTotal == null)
                return 0;

            var periodo = new DateTime(anio, mes, 1);

            if (periodo < FechaDesde || periodo > FechaHasta)
                return 0;

            int totalMeses = ((FechaHasta.Value.Year - FechaDesde.Value.Year) * 12)
                           + (FechaHasta.Value.Month - FechaDesde.Value.Month) + 1;

            if (totalMeses <= 0)
                return 0;

            decimal montoMensual = MontoTotal.Value / totalMeses;

            int mesesRestantes = ((FechaHasta.Value.Year - anio) * 12)
                               + (FechaHasta.Value.Month - mes);

            return mesesRestantes > 0 ? mesesRestantes * montoMensual : 0;
        }
        public override bool PerteneceAlMes(int mes, int anio)
        {
            DateTime inicioMes = new DateTime(anio, mes, 1);
            DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);

            return FechaDesde <= finMes && FechaHasta >= inicioMes;
        }
    }
}
