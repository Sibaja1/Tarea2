using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace Contador_de_ceros_consecutivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long numeroEntero = 0;

            solicitar_datos(ref numeroEntero);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            int max0 = contar0(numeroEntero);

            stopwatch.Stop();

            Console.WriteLine($"El número máximo de ceros consecutivos es: {max0}");

            TimeSpan tiempoTranscurrido = stopwatch.Elapsed;

            Console.WriteLine("Tiempo transcurrido: " + tiempoTranscurrido);

            Console.ReadLine();
        }

        public static void solicitar_datos(ref long numeroEntero)
        {
            do
            {
                Console.WriteLine("Ingresa un numero entero");
                string captura = Console.ReadLine();

                if (long.TryParse(captura, out numeroEntero))
                {
                    try
                    {
                        numeroEntero = long.Parse(captura);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("La entrada no es un número válido: " + ex.Message);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("El dato ingresado no es válido. Inténtalo de nuevo.");
                }
            } while (true);
        }

        public static int contar0(long numeroEntero)
        {
            string numeroBinario = ConDecBinPorToString(numeroEntero);
            Console.WriteLine(numeroBinario);

            int longitud = numeroBinario.Length;
            int cont0 = 0, max0 = 0;

            for (int i = 0; i < longitud; i++)
            {
                if (numeroBinario[i] == '0')
                {
                    cont0++;
                }
                else
                {
                    if (cont0 > max0)
                    {
                        max0 = cont0;
                    }
                    cont0 = 0;
                }
            }

            if (cont0 > max0)
            {
                max0 = cont0;
            }

            return max0;
        }
        public static string ConDecBinPorToString(long numeroEntero)
        {
            string numeroBinario = Convert.ToString(numeroEntero, 2);
            return numeroBinario;
        }
    }
}
