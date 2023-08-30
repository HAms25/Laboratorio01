// See https://aka.ms/new-console-template for more information

using Laboratorio01;

public class Program
{
    public static void Main(string[] args)
    {
        // Crear una cuenta bancaria
        CuentaBancaria cuenta = new CuentaBancaria(123456789, "Hilari Martinez", 1000, 1234);

        // Crear un cajero automático
        CajeroAutomatico cajero = new CajeroAutomatico(987654321, "Liam Enrique", 2000, 4321, 500);

        // Interacción con el usuario
        Console.WriteLine("Bienvenido al Cajero Automático");
        Console.WriteLine("Ingrese su número de cuenta:");
        int numeroCuenta = int.Parse(Console.ReadLine());

        int intentos = 0;
        bool inicioSesionExitoso = false;

        while (intentos < 3 && !inicioSesionExitoso)
        {
            Console.WriteLine("Ingrese su PIN:");
            int pin = int.Parse(Console.ReadLine());

            if (cuenta.NumeroCuenta == numeroCuenta && cuenta.VerificarPin(pin))
            {
                Console.WriteLine("Inicio de sesión exitoso.");
                inicioSesionExitoso = true;
            }
            else
            {
                Console.WriteLine("Número de cuenta o PIN incorrecto. Por favor, intente nuevamente.");
                intentos++;
            }
        }

        if (inicioSesionExitoso)
        {
            string nombreTitular = cuenta.TitularCuenta;

            Console.WriteLine("Bienvenido " + nombreTitular);

            int opcion = -1;

            while (opcion != 0)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar fondos");
                Console.WriteLine("3. Retirar efectivo");
                Console.WriteLine("4. Cambiar PIN");
                Console.WriteLine("0. Salir");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        cuenta.ConsultarSaldo();
                        break;
                    case 2:
                        Console.WriteLine("Ingrese la cantidad a depositar:");
                        decimal cantidadDeposito = decimal.Parse(Console.ReadLine());
                        cuenta.Depositar(cantidadDeposito);
                        break;
                    case 3:
                        Console.WriteLine("Ingrese la cantidad a retirar:");
                        decimal cantidadRetiro = decimal.Parse(Console.ReadLine());
                        try
                        {
                            cuenta.Retirar(cantidadRetiro);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine("Exitoso: " + ex.Message);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el PIN actual:");
                        int pinActual = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el nuevo PIN:");
                        int nuevoPin = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            cuenta.CambiarPin(pinActual, nuevoPin);
                            Console.WriteLine("El PIN se ha cambiado exitosamente. Por favor, inicie sesión nuevamente.");
                            inicioSesionExitoso = false; // Requerir inicio de sesión nuevamente
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            

        } while (opcion != 0);
        }
        else
        {
            Console.WriteLine("Número de cuenta o PIN incorrecto. Ha excedido el número máximo de intentos. El programa se cerrará.");
        }
    }
}
