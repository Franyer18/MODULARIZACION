namespace ProgramaConMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Menú de opciones:");
                Console.WriteLine("1. Calculadora básica");
                Console.WriteLine("2. Validación de contraseña");
                Console.WriteLine("3. Números primos");
                Console.WriteLine("4. Suma de números pares");
                Console.WriteLine("5. Conversión de temperatura");
                Console.WriteLine("6. Contador de vocales");
                Console.WriteLine("7. Cálculo de factorial");
                Console.WriteLine("8. Juego de adivinanza");
                Console.WriteLine("9. Paso por referencia");
                Console.WriteLine("10. Tabla de multiplicar");
                Console.WriteLine("0. Salir");
                Console.Write("Elige una opción: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        CalculadoraBasica();
                        break;
                    case 2:
                        ValidacionContrasena();
                        break;
                    case 3:
                        NumerosPrimos();
                        break;
                    case 4:
                        SumaNumerosPares();
                        break;
                    case 5:
                        ConversionTemperatura();
                        break;
                    case 6:
                        ContadorVocales();
                        break;
                    case 7:
                        CalculoFactorial();
                        break;
                    case 8:
                        JuegoAdivinanza();
                        break;
                    case 9:
                        PasoPorReferencia();
                        break;
                    case 10:
                        TablaMultiplicar();
                        break;
                }
            } while (opcion != 0);
        }

        static void CalculadoraBasica()
        {
            Console.Clear();
            Console.WriteLine("Calculadora Básica:");
            Console.Write("Ingresa el primer número: ");
            if (!double.TryParse(Console.ReadLine(), out double num1))
            {
                Console.WriteLine("Número inválido. Inténtalo de nuevo.");
                return;
            }
            Console.Write("Ingresa el segundo número: ");
            if (!double.TryParse(Console.ReadLine(), out double num2))
            {
                Console.WriteLine("Número inválido. Inténtalo de nuevo.");
                return;
            }
            Console.WriteLine("Elige una operación (+, -, *, /): ");
            string operacion = Console.ReadLine();

            double resultado = 0;
            switch (operacion)
            {
                case "+":
                    resultado = Suma(num1, num2);
                    break;
                case "-":
                    resultado = Resta(num1, num2);
                    break;
                case "*":
                    resultado = Multiplicacion(num1, num2);
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        resultado = Division(num1, num2);
                    }
                    else
                    {
                        Console.WriteLine("No se puede dividir por cero.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Operación no válida.");
                    return;
            }
            Console.WriteLine($"El resultado es: {resultado}");
            Console.ReadKey();
        }

        static double Suma(double a, double b) => a + b;
        static double Resta(double a, double b) => a - b;
        static double Multiplicacion(double a, double b) => a * b;
        static double Division(double a, double b) => a / b;

        static void ValidacionContrasena()
        {
            Console.Clear();
            string contrasena;
            do
            {
                Console.Write("Ingresa la contraseña: ");
                contrasena = Console.ReadLine();
                if (contrasena == "1234")
                {
                    Console.WriteLine("Acceso concedido.");
                    break;
                }
                else
                {
                    Console.WriteLine("Contraseña incorrecta. Inténtalo de nuevo.");
                }
            } while (true);
            Console.ReadKey();
        }

        static void NumerosPrimos()
        {
            Console.Clear();
            Console.Write("Ingresa un número entero: ");
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                bool esPrimo = EsPrimo(numero);
                Console.WriteLine(esPrimo ? "El número es primo." : "El número no es primo.");
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }
            Console.ReadKey();
        }

        static bool EsPrimo(int num)
        {
            if (num <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        static void SumaNumerosPares()
        {
            Console.Clear();
            int suma = 0, numero;
            Console.WriteLine("Ingresa números enteros (0 para terminar): ");
            while (int.TryParse(Console.ReadLine(), out numero) && numero != 0)
            {
                if (numero % 2 == 0)
                {
                    suma += numero;
                }
            }
            Console.WriteLine($"La suma de los números pares ingresados es: {suma}");
            Console.ReadKey();
        }

        static void ConversionTemperatura()
        {
            Console.Clear();
            Console.Write("Elige una conversión (1. Celsius a Fahrenheit, 2. Fahrenheit a Celsius): ");
            int.TryParse(Console.ReadLine(), out int opcion);
            Console.Write("Ingresa el valor a convertir: ");
            if (double.TryParse(Console.ReadLine(), out double valor))
            {
                double resultado = 0;
                if (opcion == 1)
                {
                    resultado = CelsiusAFahrenheit(valor);
                    Console.WriteLine($"{valor} °C = {resultado} °F");
                }
                else if (opcion == 2)
                {
                    resultado = FahrenheitACelsius(valor);
                    Console.WriteLine($"{valor} °F = {resultado} °C");
                }
                else
                {
                    Console.WriteLine("Opción no válida.");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
            Console.ReadKey();
        }

        static double CelsiusAFahrenheit(double c) => (c * 9 / 5) + 32;
        static double FahrenheitACelsius(double f) => (f - 32) * 5 / 9;

        static void ContadorVocales()
        {
            Console.Clear();
            Console.Write("Ingresa una frase: ");
            string frase = Console.ReadLine();
            int cantidadVocales = ContarVocales(frase);
            Console.WriteLine($"La frase contiene {cantidadVocales} vocales.");
            Console.ReadKey();
        }

        static int ContarVocales(string texto)
        {
            int contador = 0;
            foreach (char c in texto)
            {
                if ("aeiouAEIOU".IndexOf(c) >= 0)
                {
                    contador++;
                }
            }
            return contador;
        }

        static void CalculoFactorial()
        {
            Console.Clear();
            Console.Write("Ingresa un número entero: ");
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                long factorial = CalcularFactorial(numero);
                Console.WriteLine($"El factorial de {numero} es {factorial}");
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }
            Console.ReadKey();
        }

        static long CalcularFactorial(int num)
        {
            long resultado = 1;
            for (int i = 1; i <= num; i++)
            {
                resultado *= i;
            }
            return resultado;
        }

        static void JuegoAdivinanza()
        {
            Console.Clear();
            Random rand = new Random();
            int numeroAleatorio = rand.Next(1, 101);
            int intento;
            do
            {
                Console.Write("Adivina el número (entre 1 y 100): ");
                if (int.TryParse(Console.ReadLine(), out intento))
                {
                    if (intento < numeroAleatorio)
                    {
                        Console.WriteLine("Demasiado bajo.");
                    }
                    else if (intento > numeroAleatorio)
                    {
                        Console.WriteLine("Demasiado alto.");
                    }
                    else
                    {
                        Console.WriteLine("¡Correcto! Has adivinado el número.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Número inválido.");
                }
            } while (true);
            Console.ReadKey();
        }

        static void PasoPorReferencia()
        {
            Console.Clear();
            Console.WriteLine("Paso por Referencia:");
            Console.Write("Ingresa un número: ");
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                Incrementar(ref numero);
                Console.WriteLine($"El número incrementado es: {numero}");
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }
            Console.ReadKey();
        }

        static void Incrementar(ref int num)
        {
            num++;
        }

        static void TablaMultiplicar()
        {
            Console.Clear();
            Console.Write("Ingresa un número entero: ");
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine($"Tabla de multiplicar del {numero}:");
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"{numero} x {i} = {numero * i}");
                }
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }
            Console.ReadKey();
        }
    }
}
