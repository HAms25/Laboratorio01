using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio01
{
    public class CuentaBancaria
    {
        public int NumeroCuenta { get; set; }
        public string TitularCuenta { get; set; }
        public decimal Saldo { get; set; }
        private int Pin { get; set; }

        public CuentaBancaria(int numeroCuenta, string titularCuenta, decimal saldo, int pin)
        {
            NumeroCuenta = numeroCuenta;
            TitularCuenta = titularCuenta;
            Saldo = saldo;
            Pin = pin;
        }

        public bool VerificarPin(int pin)
        {
            return Pin == pin;
        }

        public virtual void ConsultarSaldo()
        {
            Console.WriteLine("Saldo actual: $" + Saldo);
        }

        public virtual void Depositar(decimal cantidad)
        {
            Saldo += cantidad;
            Console.WriteLine("Depósito exitoso. Saldo actual: $" + Saldo);
        }

        public virtual void Retirar(decimal cantidad)
        {
            if (cantidad <= Saldo)
            {
                Saldo -= cantidad;
                Console.WriteLine("Retiro exitoso. Saldo actual: $" + Saldo);
            }
            else
            {
                throw new InvalidOperationException("Saldo insuficiente.");
            }
        }

        public bool CambiarPin(int pinActual, int nuevoPin)
        {
            if (Pin == pinActual && Pin != nuevoPin)
            {
                Pin = nuevoPin;
                throw new InvalidOperationException("El cambio de PIN se realizó exitosamente. Por favor, inicie sesión nuevamente.");
            }

            return false;
        }
    }
}
