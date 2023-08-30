using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio01
{
    public class CajeroAutomatico : CuentaBancaria
    {
        private decimal LimiteRetiroDiario { get; set; }

        public CajeroAutomatico(int numeroCuenta, string titularCuenta, decimal saldo, int pin, decimal limiteRetiroDiario)
            : base(numeroCuenta, titularCuenta, saldo, pin)
        {
            LimiteRetiroDiario = limiteRetiroDiario;
        }

        public override void Retirar(decimal cantidad)
        {
            if (cantidad <= Saldo && cantidad <= LimiteRetiroDiario)
            {
                Saldo -= cantidad;
                Console.WriteLine("Retiro exitoso. Saldo actual: $" + Saldo);
            }
            else if (cantidad > LimiteRetiroDiario)
            {
                throw new InvalidOperationException("El monto de retiro excede el límite diario.");
            }
            else
            {
                throw new InvalidOperationException("Saldo insuficiente.");
            }
        }
    }
}
