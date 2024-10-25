using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIcorteevaluacion
{
    internal class Funcioneslista
    {
        public List<int> IngresarNumeros()
        {
            List<int> numeros = new List<int>();
            Console.WriteLine("Ingrese números enteros positivos entre 50 y 100 (0 para terminar):");
            int num;

            do
            {
                num = Convert.ToInt32(Console.ReadLine());
                if (num >= 50 && num <= 100)
                {
                    numeros.Add(num);
                }
                else if (num != 0)
                {
                    Console.WriteLine("El número debe estar entre 50 y 100.");
                }
            } while (num != 0);

            return numeros;
        }

        public void GuardarEnArchivo(List<int> numeros, string archivo)
        {
            using (FileStream fs = new FileStream(archivo, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                foreach (int numero in numeros)
                {
                    writer.Write(numero);
                }
            }
        }

        public List<int> LeerDesdeArchivo(string archivo)
        {
            List<int> numeros = new List<int>();

            using (FileStream fs = new FileStream(archivo, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    numeros.Add(reader.ReadInt32());
                }
            }

            return numeros;
        }

        public void MostrarTodos(List<int> numeros)
        {
            Console.WriteLine("Todos los números:");
            foreach (int numero in numeros)
            {
                Console.WriteLine(numero);
            }
        }

        public void MostrarMayor(List<int> numeros)
        {
            int mayor = numeros.Max();
            Console.WriteLine("El número mayor es: " + mayor);
        }

        public void MostrarMenor(List<int> numeros)
        {
            int menor = numeros.Min();
            Console.WriteLine("El número menor es: " + menor);
        }

        public void MostrarPromedio(List<int> numeros)
        {
            double promedio = numeros.Average();
            Console.WriteLine("El promedio de los números es: " + promedio);
        }
    }
}
