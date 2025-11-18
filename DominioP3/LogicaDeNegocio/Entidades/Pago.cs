using LogicaDeNegocio.Enums;
using LogicaDeNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public abstract class Pago : IValidable
    {
        public int Id { get; set; }
        public MetodoDePago MetodoDePago { get; set; }
        public string Descripcion { get; set; }
        public TipoDeGasto TipoDeGasto { get; set; }
        [ForeignKey("TipoDeGasto")]
        public int TipoDeGastoId { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public decimal? MontoTotal { get; set; }
        
        public Pago() { }
        public abstract decimal? CalcularSaldoPendiente(int mes, int año);

        public abstract void Validar();

        public abstract bool PerteneceAlMes(int mes, int anio);
    }
}
