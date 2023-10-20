using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadFinanciera
{
    public class TarjetaCredito
    {
        public int id {  get; set; }
        public int nroTarjeta {  get; set; }
        public double limiteCredito { get; set; }
        public double saldoDisponible { get; set;}
        public double montoDeuda { get; set; }
        public string estado {  get; set; }
        public Cliente clienteTarjetaCredito { get; set; }

    }
}
