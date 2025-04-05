using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonactivaRD
{
    public static class DonanteHelper
    {
        public static void MenuDonantes(List<Donante> donantes)
        {
            int opcion = 0;
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- Menú Donantes ---");
                Console.WriteLine("1. Agregar Donante");
                Console.WriteLine("2. Editar Donante");
                Console.WriteLine("3. Listar Donantes");
                Console.WriteLine("4. Buscar Donante");
                Console.WriteLine("5. Eliminar Donante");
                Console.WriteLine("6. Volver al menú principal");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarDonante(donantes);
                        break;
                    case 2:
                        Console.WriteLine("Ingrese el ID del donante a editar:");
                        int idEditar = Convert.ToInt32(Console.ReadLine());
                        EditarDonante(donantes, idEditar);
                        break;
                    case 3:
                        ListarDonantes(donantes);
                        break;
                    case 4:
                        Console.WriteLine("Ingrese un nombre o cédula para buscar:");
                        string criterio = Console.ReadLine();
                        BuscarDonante(donantes, criterio);
                        break;
                    case 5:
                        Console.WriteLine("Ingrese el ID del donante a eliminar:");
                        int idEliminar = Convert.ToInt32(Console.ReadLine());
                        EliminarDonante(donantes, idEliminar);
                        break;
                    case 6:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }

        public static void AgregarDonante(List<Donante> donantes)
        {
            Donante nuevo = new Donante();
            nuevo.Id = donantes.Count + 1;

            Console.WriteLine("Nombre completo:");
            nuevo.Nombre = Console.ReadLine();

            Console.WriteLine("Correo electrónico:");
            nuevo.Correo = Console.ReadLine();

            Console.WriteLine("Teléfono:");
            nuevo.Telefono = Console.ReadLine();

            Console.WriteLine("Cédula:");
            nuevo.Cedula = Console.ReadLine();

            Console.WriteLine("Dirección:");
            nuevo.Direccion = Console.ReadLine();

            Console.WriteLine("Tipo de donante (Individual o Empresa):");
            nuevo.Tipo = Console.ReadLine();

            donantes.Add(nuevo);
            Console.WriteLine("Donante agregado exitosamente.");
        }

        public static void EditarDonante(List<Donante> donantes, int id)
        {
            var donante = donantes.FirstOrDefault(d => d.Id == id);

            if (donante == null)
            {
                Console.WriteLine("Donante no encontrado.");
                return;
            }

            Console.WriteLine("Editar Nombre:");
            donante.Nombre = Console.ReadLine();

            Console.WriteLine("Editar Correo:");
            donante.Correo = Console.ReadLine();

            Console.WriteLine("Editar Teléfono:");
            donante.Telefono = Console.ReadLine();

            Console.WriteLine("Editar Cédula:");
            donante.Cedula = Console.ReadLine();

            Console.WriteLine("Editar Dirección:");
            donante.Direccion = Console.ReadLine();

            Console.WriteLine("Editar Tipo de Donante:");
            donante.Tipo = Console.ReadLine();

            Console.WriteLine("Donante editado exitosamente.");
        }

        public static void ListarDonantes(List<Donante> donantes)
        {
            if (!donantes.Any())
            {
                Console.WriteLine("No hay donantes registrados.");
                return;
            }

            Console.WriteLine("ID\tNombre\t\tCorreo\t\tTeléfono\tTipo");
            foreach (var d in donantes)
            {
                Console.WriteLine($"{d.Id}\t{d.Nombre}\t{d.Correo}\t{d.Telefono}\t{d.Tipo}");
            }
        }

        public static void BuscarDonante(List<Donante> donantes, string criterio)
        {
            var resultados = donantes
                .Where(d => d.Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase)
                         || d.Cedula.Contains(criterio))
                .ToList();

            if (!resultados.Any())
            {
                Console.WriteLine("No se encontraron donantes.");
                return;
            }

            Console.WriteLine("Resultados de la búsqueda:");
            foreach (var d in resultados)
            {
                Console.WriteLine($"ID: {d.Id}, Nombre: {d.Nombre}, Cédula: {d.Cedula}, Tipo: {d.Tipo}");
            }
        }

        public static void EliminarDonante(List<Donante> donantes, int id)
        {
            var donante = donantes.FirstOrDefault(d => d.Id == id);

            if (donante == null)
            {
                Console.WriteLine("Donante no encontrado.");
                return;
            }

            donantes.Remove(donante);
            Console.WriteLine("Donante eliminado correctamente.");
        }
    }
}
