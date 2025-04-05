using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonactivaRD
{
    public static class DonacionHelper
    {
        public static void MenuDonaciones(List<Donacion> donaciones, List<Donante> donantes, List<Organizacion> organizaciones, List<Campaña> campañas)
        {
            int opcion = 0;
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- Menú Donaciones ---");
                Console.WriteLine("1. Registrar Donación");
                Console.WriteLine("2. Mostrar Donaciones");
                Console.WriteLine("3. Buscar Donaciones por Donante");
                Console.WriteLine("4. Eliminar Donación");
                Console.WriteLine("5. Volver al menú principal");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarDonacion(donaciones, donantes, organizaciones, campañas);
                        break;
                    case 2:
                        ListarDonaciones(donaciones);
                        break;
                    case 3:
                        Console.WriteLine("Ingrese nombre o cédula del donante:");
                        string criterio = Console.ReadLine();
                        BuscarDonacionesPorDonante(donaciones, donantes, criterio);
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el ID de la donación a eliminar:");
                        int idEliminar = Convert.ToInt32(Console.ReadLine());
                        EliminarDonacion(donaciones, idEliminar);
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

        public static void RegistrarDonacion(List<Donacion> donaciones, List<Donante> donantes, List<Organizacion> organizaciones, List<Campaña> campañas)
        {
            Donacion nueva = new Donacion();
            nueva.Id = donaciones.Count + 1;

            Console.WriteLine("Ingrese el ID del Donante:");
            DonanteHelper.ListarDonantes(donantes);
            nueva.DonanteId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el ID de la Organización receptora:");
            OrganizacionHelper.ListarOrganizaciones(organizaciones);
            nueva.OrganizacionId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el ID de la Campaña asociada:");
            CampañaHelper.ListarCampañas(campañas);
            nueva.CampañaId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el tipo de donación (dinero, alimento, etc.):");
            nueva.Tipo = Console.ReadLine();

            Console.WriteLine("Ingrese el monto o descripción:");
            nueva.Descripcion = Console.ReadLine();

            Console.WriteLine("Fecha de la donación (YYYY-MM-DD):");
            nueva.Fecha = DateTime.Parse(Console.ReadLine());

            donaciones.Add(nueva);
            Console.WriteLine("Donación registrada exitosamente.");
        }

        public static void ListarDonaciones(List<Donacion> donaciones)
        {
            if (!donaciones.Any())
            {
                Console.WriteLine("No hay donaciones registradas.");
                return;
            }

            Console.WriteLine("\nID\tDonanteID\tOrganizacionID\tCampañaID\tTipo\t\tMonto/Descripción\tFecha");
            foreach (var d in donaciones)
            {
                Console.WriteLine($"{d.Id}\t{d.DonanteId}\t\t{d.OrganizacionId}\t\t{d.CampañaId}\t\t{d.Tipo}\t\t{d.Descripcion}\t\t\t{d.Fecha.ToShortDateString()}");
            }
        }

        public static void BuscarDonacionesPorDonante(List<Donacion> donaciones, List<Donante> donantes, string criterio)
        {
            var donante = donantes.FirstOrDefault(d => d.Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase)
                                                     || d.Cedula.Contains(criterio));

            if (donante == null)
            {
                Console.WriteLine("Donante no encontrado.");
                return;
            }

            var resultados = donaciones.Where(d => d.DonanteId == donante.Id).ToList();

            if (!resultados.Any())
            {
                Console.WriteLine("Este donante no tiene donaciones registradas.");
                return;
            }

            Console.WriteLine($"Donaciones realizadas por: {donante.Nombre}");
            foreach (var d in resultados)
            {
                Console.WriteLine($"ID: {d.Id}, Tipo: {d.Tipo}, Monto/Descripción: {d.Descripcion}, Fecha: {d.Fecha.ToShortDateString()}");
            }
        }

        public static void EliminarDonacion(List<Donacion> donaciones, int id)
        {
            var donacion = donaciones.FirstOrDefault(d => d.Id == id);

            if (donacion == null)
            {
                Console.WriteLine("Donación no encontrada.");
                return;
            }

            donaciones.Remove(donacion);
            Console.WriteLine("Donación eliminada correctamente.");
        }
    }
}
