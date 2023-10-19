using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadFinanciera
{
    public class Principal
    {
        AplicationDbContext context = new AplicationDbContext();

        BaseDatos baseDatos = new BaseDatos();

        public void AgregarCliente(Cliente nuevoCliente)
        {
            context.Clientes.Add(nuevoCliente);
            context.SaveChanges();         
        }
                
        public void AgregarCuentaBancaria (Cliente nuevoCliente)
        {
                      
        }




    }

    
}
