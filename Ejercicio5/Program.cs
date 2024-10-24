using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorPuntuaciones gestor = new GestorPuntuaciones();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("1. Agregar puntuación");
                Console.WriteLine("2. Eliminar puntuación");
                Console.WriteLine("3. Mostrar puntuaciones");
                Console.WriteLine("4. Salir");
                Console.Write("Selecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el nombre del jugador: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese la puntuación: ");
                        int puntuacion = int.Parse(Console.ReadLine());
                        gestor.AgregarPuntuacion(nombre, puntuacion);
                        break;

                    case "2":
                        Console.Write("Ingrese el nombre del jugador a eliminar: ");
                        string nombreEliminar = Console.ReadLine();
                        gestor.EliminarPuntuacion(nombreEliminar);
                        break;

                    case "3":
                        gestor.MostrarPuntuaciones();
                        break;

                    case "4":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
