using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIcorteevaluacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Funcioneslista funciones = new Funcioneslista();

                List<int> numeros = funciones.IngresarNumeros();
                funciones.GuardarEnArchivo(numeros, "numeros.bin");
                List<int> numerosLeidos = funciones.LeerDesdeArchivo("numeros.bin");

                bool continuar = true;

                while (continuar)
                {
                    Console.WriteLine("\nSeleccione una opción:");
                    Console.WriteLine("1 - Mostrar todos los números");
                    Console.WriteLine("2 - Mostrar el número mayor");
                    Console.WriteLine("3 - Mostrar el número menor");
                    Console.WriteLine("4 - Mostrar el promedio de los números");
                    Console.WriteLine("5 - Salir");
                    Console.Write("Opción: ");

                    if (int.TryParse(Console.ReadLine(), out int opcion))
                    {
                        switch (opcion)
                        {
                            case 1:
                                funciones.MostrarTodos(numerosLeidos);
                                break;
                            case 2:
                                funciones.MostrarMayor(numerosLeidos);
                                break;
                            case 3:
                                funciones.MostrarMenor(numerosLeidos);
                                break;
                            case 4:
                                funciones.MostrarPromedio(numerosLeidos);
                                break;
                            case 5:
                                continuar = false;
                                break;
                            default:
                                Console.WriteLine("Opción no válida. Intente de nuevo.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida. Intente de nuevo.");
                    }

                    // Pausar el programa para que el usuario vea el resultado antes de limpiar
                    if (continuar)
                    {
                        Console.WriteLine("\nPresione Enter para continuar...");
                        Console.ReadLine();
                    }
                }

                Console.WriteLine("Gracias por usar el programa.");
            }
        }
    }                                                        