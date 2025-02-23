using System;

// Definimos la clase CuentaBancaria
class CuentaBancaria
{
    // agregamos los Atributos privados para encapsulación
    private string titular;
    private decimal saldo;

    //la Construcion de la clase para inicializar valores
    public CuentaBancaria(string titular, decimal saldoInicial)
    {
        this.titular = titular;
        this.saldo = saldoInicial;
    }

    // Método para depositar dinero en la cuenta
    public void Depositar(decimal monto)
    {
        if (monto > 0)
        {
            saldo += monto;
            Console.WriteLine($"Titular: {titular}");
            Console.WriteLine($"Nuevo saldo RD${saldo}");
        }
        else
        {
            Console.WriteLine("Error: No se puede depositar un monto negativo o cero.");
        }
    }

    // Método para retirar dinero de la cuenta
    public void Retirar(decimal monto)
    {
        if (monto > 0 && monto <= saldo)
        {
            saldo -= monto;
            Console.WriteLine($"Titular: {titular}");
            Console.WriteLine($"Nuevo saldo RD${saldo}");
        }
        else if (monto > saldo)
        {
            Console.WriteLine("Error: Fondos insuficientes.");
        }
        else
        {
            Console.WriteLine("Error: No se puede retirar un monto negativo o cero.");
        }
    }

    // Método para mostrar la información de la cuenta
    public void MostrarInformacion()
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine($"Titular: {titular}");
        Console.WriteLine($"Saldo: RD${saldo}");
        Console.WriteLine("---------------------------");
    }
}

class Program
{
    static void Main()
    {
        // Creamos instancias de la clase con titulares y saldo inicial
        CuentaBancaria cuenta1 = new CuentaBancaria("Cristian ALcides", 3000);
        CuentaBancaria cuenta2 = new CuentaBancaria("Diego Lauriano", 5000);

        // Mostrar información inicial de las cuentas
        cuenta1.MostrarInformacion();
        cuenta2.MostrarInformacion();

        // Menú interactivo
        while (true)
        {
            Console.WriteLine("\n--- Menú de Cuenta Bancaria ---");
            Console.WriteLine("1. Depositar");
            Console.WriteLine("2. Retirar");
            Console.WriteLine("3. Mostrar información");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                continue;
            }

            CuentaBancaria cuentaSeleccionada = null;
            Console.Write("Seleccione la cuenta (1 para Cristian Alcides , 2 para Diego Lauriano): ");
            int cuentaOpcion = int.Parse(Console.ReadLine());
            if (cuentaOpcion == 1) cuentaSeleccionada = cuenta1;
            else if (cuentaOpcion == 2) cuentaSeleccionada = cuenta2;
            else
            {
                Console.WriteLine("Cuenta inválida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el monto a depositar: ");
                    decimal montoDeposito = decimal.Parse(Console.ReadLine());
                    cuentaSeleccionada.Depositar(montoDeposito);
                    break;
                case 2:
                    Console.Write("Ingrese el monto a retirar: ");
                    decimal montoRetiro = decimal.Parse(Console.ReadLine());
                    cuentaSeleccionada.Retirar(montoRetiro);
                    break;
                case 3:
                    cuentaSeleccionada.MostrarInformacion();
                    break;
                case 4:
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}
