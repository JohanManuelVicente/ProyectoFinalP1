using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonactivaRD
{
    public static class CampañaHelper
    {
        public static void MenuCampañas(List<Campaña> campañas)
        {
            int opcion = 0;
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- Menú Campañas ---");
                Console.WriteLine("1. Registrar Campaña");
                Console.WriteLine("2. Mostrar Campañas");
                Console.WriteLine("3. Buscar Campaña por Nombre");
                Console.WriteLine("4. Eliminar Campaña");
                Console.WriteLine("5. Volver al menú principal");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarCampaña(campañas);
                        break;
                    case 2:
                        ListarCampañas(campañas);
                        break;
                    case 3:
                        Console.WriteLine("Ingrese el nombre de la campaña:");
                        string criterio = Console.ReadLine();
                        BuscarCampaña(campañas, criterio);
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el ID de la campaña a eliminar:");
                        int idEliminar = Convert.ToInt32(Console.ReadLine());
                        EliminarCampaña(campañas, idEliminar);
                        break;
                    case 5:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }

        public static void RegistrarCampaña(List<Campaña> campañas)
        {
            Campaña nueva = new Campaña();
            nueva.Id = campañas.Count + 1;

            Console.WriteLine("Ingrese el nombre de la campaña:");
            nueva.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la descripción de la campaña:");
            nueva.Descripcion = Console.ReadLine();

            Console.WriteLine("Fecha de inicio de la campaña (YYYY-MM-DD):");
            nueva.FechaInicio = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Fecha de finalización de la campaña (YYYY-MM-DD):");
            nueva.FechaFin = DateTime.Parse(Console.ReadLine());

            campañas.Add(nueva);
            Console.WriteLine("Campaña registrada exitosamente.");
        }

        public static void ListarCampañas(List<Campaña> campañas)
        {
            if (!campañas.Any())
            {
                Console.WriteLine("No hay campañas registradas.");
                return;
            }

            Console.WriteLine("ID\tNombre\t\tFecha Inicio\tFecha Fin\tDescripción");
            foreach (var c in campañas)
            {
                Console.WriteLine($"{c.Id}\t{c.Nombre}\t\t{c.FechaInicio.ToShortDateString()}\t{c.FechaFin.ToShortDateString()}\t{c.Descripcion}");
            }
        }

        public static void BuscarCampaña(List<Campaña> campañas, string nombre)
        {
            var resultados = campañas.Where(c => c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!resultados.Any())
            {
                Console.WriteLine("No se encontraron campañas con ese nombre.");
                return;
            }

            Console.WriteLine("ID\tNombre\t\tFecha Inicio\tFecha Fin\tDescripción");
            foreach (var c in resultados)
            {
                Console.WriteLine($"{c.Id}\t{c.Nombre}\t\t{c.FechaInicio.ToShortDateString()}\t{c.FechaFin.ToShortDateString()}\t{c.Descripcion}");
            }
        }

        public static void EliminarCampaña(List<Campaña> campañas, int id)
        {
            var campaña = campañas.FirstOrDefault(c => c.Id == id);

            if (campaña == null)
            {
                Console.WriteLine("Campaña no encontrada.");
                return;
            }

            campañas.Remove(campaña);
            Console.WriteLine("Campaña eliminada correctamente.");
        }
    }
}
