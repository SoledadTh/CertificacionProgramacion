using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadFinanciera
{
    public class CuentaBancaria
    {
        public int Id { get; set; }
        public long numeroCuenta { get; set; }
        public double saldo { get; set; }
        public string tipo { get; set; }
        public Cliente clienteCuentaBancaria { get; set; }
    }
}
