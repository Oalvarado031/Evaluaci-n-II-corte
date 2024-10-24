using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    internal class GestorPuntuaciones
    {
        private string rutaArchivo = "puntuaciones.bin";

        // Agrega una nueva puntuación al archivo binario.
        public void AgregarPuntuacion(string nombreJugador, int puntuacion)
        {
            List<PuntuacionJugador> puntuaciones = CargarPuntuaciones();
            puntuaciones.Add(new PuntuacionJugador(nombreJugador, puntuacion));
            GuardarPuntuaciones(puntuaciones);
            Console.WriteLine("Puntuación agregada correctamente.");
        }

        // Elimina una puntuación según el nombre del jugador.
        public void EliminarPuntuacion(string nombreJugador)
        {
            List<PuntuacionJugador> puntuaciones = CargarPuntuaciones();
            puntuaciones.RemoveAll(p => p.NombreJugador == nombreJugador);
            GuardarPuntuaciones(puntuaciones);
            Console.WriteLine("Puntuación eliminada correctamente.");
        }

        // Muestra todas las puntuaciones de los jugadores.
        public void MostrarPuntuaciones()
        {
            List<PuntuacionJugador> puntuaciones = CargarPuntuaciones();
            if (puntuaciones.Count == 0)
            {
                Console.WriteLine("No hay puntuaciones registradas.");
                return;
            }

            Console.WriteLine("Puntuaciones de jugadores:");
            foreach (var puntuacion in puntuaciones)
            {
                Console.WriteLine($"Jugador: {puntuacion.NombreJugador}, Puntuación: {puntuacion.Puntuacion}");
            }
        }

        // Carga las puntuaciones desde un archivo binario.
        private List<PuntuacionJugador> CargarPuntuaciones()
        {
            if (!File.Exists(rutaArchivo))
            {
                return new List<PuntuacionJugador>();
            }

            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                List<PuntuacionJugador> puntuaciones = new List<PuntuacionJugador>();
                while (fs.Position < fs.Length)
                {
                    string nombreJugador = reader.ReadString();
                    int puntuacion = reader.ReadInt32();
                    puntuaciones.Add(new PuntuacionJugador(nombreJugador, puntuacion));
                }
                return puntuaciones;
            }
        }

        // Guarda las puntuaciones en un archivo binario.
        private void GuardarPuntuaciones(List<PuntuacionJugador> puntuaciones)
        {
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                foreach (var puntuacion in puntuaciones)
                {
                    writer.Write(puntuacion.NombreJugador);
                    writer.Write(puntuacion.Puntuacion);
                }
            }
        }

        // Clase interna para representar la puntuación de un jugador.
        private class PuntuacionJugador
        {
            public string NombreJugador { get; }
            public int Puntuacion { get; }

            public PuntuacionJugador(string nombreJugador, int puntuacion)
            {
                NombreJugador = nombreJugador;
                Puntuacion = puntuacion;
            }
        }
    }
}
