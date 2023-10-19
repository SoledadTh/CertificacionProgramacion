using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadFinanciera
{
    public class BaseDatos
    { }
    public class AplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TarjetaCredito> TarjetasCreditos { get; set; }
        public DbSet<CuentaBancaria> cuentaBancarias { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=EntidadFinanciera;trusted_connection=true;Encrypt=False");
        }
    }
}

