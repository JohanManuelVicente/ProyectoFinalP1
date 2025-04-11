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
                try
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
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                }
            }
        }

        public static void RegistrarCampaña(List<Campaña> campañas)
        {
            try
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
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido. Asegúrese de ingresar las fechas en el formato correcto.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar campaña: {ex.Message}");
            }
        }

        public static void ListarCampañas(List<Campaña> campañas)
        {
            try
            {
                if (!campañas.Any())
                {
                    Console.WriteLine("No hay campañas registradas.");
                    return;
                }

                Console.WriteLine();
                foreach (var c in campañas)
                {
                    Console.WriteLine($"ID: {c.Id}\tNombre: {c.Nombre}\tFecha Inicio: {c.FechaInicio.ToShortDateString()}\tFecha Fin: {c.FechaFin.ToShortDateString()}\t\tDescripción: {c.Descripcion}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar campañas: {ex.Message}");
            }
        }

        public static void BuscarCampaña(List<Campaña> campañas, string nombre)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar campaña: {ex.Message}");
            }
        }

        public static void EliminarCampaña(List<Campaña> campañas, int id)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar campaña: {ex.Message}");
            }
        }
    }
}
