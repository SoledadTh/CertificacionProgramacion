using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadFinanciera
{
    // AgregarCliente(): Agregar un nuevo cliente a la base de datos. Modo simple.
    public class Principal
    {
        AplicationDbContext context = new AplicationDbContext();

        BaseDatos baseDatos = new BaseDatos();

        public void AgregarCliente(Cliente nuevoCliente)
        {
            context.Clientes.Add(nuevoCliente);
            context.SaveChanges();
        }

        // CrearCuentaBancaria(): Crear una nueva cuenta bancaria para un cliente existente.
        public void AgregarCuentaBancaria(string tipo, int idCliente, double saldo)
        {
            CuentaBancaria CuentasBancarias = new CuentaBancaria();

            var elClienteEncontrado = context.Clientes.Find(idCliente);

            if (elClienteEncontrado != null)
            {
                CuentasBancarias.clienteCuentaBancaria = elClienteEncontrado;
                CuentasBancarias.saldo = 0;
                CuentasBancarias.tipo = tipo;

                var nroCuenta = (elClienteEncontrado.dni).ToString();

                if (tipo == "CC")
                {
                    nroCuenta = nroCuenta + "1111";
                }
                else
                {
                    nroCuenta = nroCuenta + "2222";
                }

                CuentasBancarias.numeroCuenta = long.Parse(nroCuenta);

                // RealizarDeposito(): Realizar un depósito en una cuenta bancaria.

                var deposito = context.CuentasBancarias.Find(nroCuenta);

                if (deposito != null)
                {
                    saldo = saldo + deposito.saldo;
                }
                //	RealizarExtraccion(): Realizar una extracción de una cuenta bancaria.
                var extraccion = context.CuentasBancarias.Find(nroCuenta);

                if (saldo >= extraccion.saldo)
                {
                    saldo = saldo - extraccion.saldo;
                }

                // RealizarTransferencia(): Transferir dinero entre cuentas bancarias.

                




            }

            context.CuentasBancarias.Add(CuentasBancarias);
            context.SaveChanges();
        }

        // EmitirTarjetaCredito(): Emitir una nueva tarjeta de crédito para un cliente existente.
        public void AgregarTarjetaCredito(int idCliente, string estado, double montoDeuda, double saldo)
        {
            TarjetaCredito TarjetasCreditos = new TarjetaCredito();

            var elClienteEncontrado = context.Clientes.Find(idCliente);

            if (elClienteEncontrado != null)
            {
                TarjetasCreditos.clienteTarjetaCredito = elClienteEncontrado;
                TarjetasCreditos.montoDeuda = 0;
                TarjetasCreditos.limiteCredito = 0;
                TarjetasCreditos.saldoDisponible = 0;

                var nroTarjeta = (elClienteEncontrado.dni).ToString();

                nroTarjeta = "9040" + nroTarjeta;
                               

                // PausarTarjetaCredito(): Emitir una pausa o “Baja logica” de una tarjeta para un cliente existente.

                var tarjetaCreditoEncontrada = context.TarjetasCreditos.Find(nroTarjeta);

                if (nroTarjeta != null)
                {
                    tarjetaCreditoEncontrada.estado = estado;

                    if (estado == "Activa")
                    {
                        tarjetaCreditoEncontrada.estado = "Pausada";
                    }
                }

                // PagarTarjetaCredito(): Realizar un pago a una tarjeta de crédito.

                var deudaTarjeta = context.TarjetasCreditos.Find(montoDeuda);
                var saldoDisponibleCuenta = context.CuentasBancarias.Find(saldo);

                if (saldoDisponibleCuenta != null, deudaTarjeta != null)
                {
                    if (saldoDisponibleCuenta.saldo >= deudaTarjeta.montoDeuda)
                    {
                        deudaTarjeta.montoDeuda = 0;
                    }
                }

                //	GenerarResumenTarjeta(): Generar un resumen de tarjeta de crédito.






                context.TarjetasCreditos.Add(TarjetasCreditos);
                context.SaveChanges();
            }
        }
    }
}
