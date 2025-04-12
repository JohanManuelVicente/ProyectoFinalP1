using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonactivaRD
{
    public static class DonanteHelper
    {
        public static void MenuDonantes()
        {
            int opcion = 0;
            bool continuar = true;

            while (continuar)
            {
                try
                {
                    var context = new DonactivaRD_DataContext();
                    var donantes = context.Donante.ToList();
                    Console.WriteLine("\n--- Menú Donantes ---");
                    Console.WriteLine("1. Agregar Donante");
                    Console.WriteLine("2. Editar Donante");
                    Console.WriteLine("3. Mostrar Donantes");
                    Console.WriteLine("4. Buscar Donante");
                    Console.WriteLine("5. Eliminar Donante");
                    Console.WriteLine("6. Volver al menú principal");

                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            AgregarDonante();
                            break;
                        case 2:
                            Console.WriteLine("Ingrese el ID del donante a editar:");
                            int idEditar = Convert.ToInt32(Console.ReadLine());
                            EditarDonante(idEditar);
                            break;
                        case 3:
                            ListarDonantes();
                            break;
                        case 4:
                            Console.WriteLine("Ingrese un nombre o cédula para buscar:");
                            string criterio = Console.ReadLine();
                            BuscarDonante( criterio);
                            break;
                        case 5:
                            Console.WriteLine("Ingrese el ID del donante a eliminar:");
                            int idEliminar = Convert.ToInt32(Console.ReadLine());
                            EliminarDonante( idEliminar);
                            break;
                        case 6:
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

        public static void AgregarDonante()
        {
            try
            {
                var context = new DonactivaRD_DataContext();

                Donante nuevo = new Donante();
                nuevo.Id = context.Donante.Count();

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

                context.Donante.Add(nuevo);
                Console.WriteLine("Donante agregado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar donante: {ex.Message}");
            }
        }

        public static void EditarDonante(int id)
        {
            try
            {
                var context = new DonactivaRD_DataContext();
                Donante nuevo = new Donante();

                var donante = context.Donante.FirstOrDefault(d => d.Id == id);

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
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar donante: {ex.Message}");
            }
        }

        public static void ListarDonantes()
        {
            var context = new DonactivaRD_DataContext();
            Donante nuevo = new Donante();
            if (!context.Donante.Any())
            {
                Console.WriteLine("No hay donantes registrados.");
                return;
            }

            Console.WriteLine();
            foreach (var d in context.Donante)
            {
                Console.WriteLine($"ID: {d.Id}\tNombre: {d.Nombre}\tCorreo: {d.Correo}\tTeléfono: {d.Telefono}\tTipo: {d.Tipo}");
            }
        }

        public static void BuscarDonante(string criterio)
        {
            try
            {
                var context = new DonactivaRD_DataContext();
                Donante nuevo = new Donante();

                var resultados = context.Donante
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante la búsqueda: {ex.Message}");
            }
        }

        public static void EliminarDonante(int id)
        {
            try
            {
                var context = new DonactivaRD_DataContext();
                Donante nuevo = new Donante();
                var donante = context.Donante.FirstOrDefault(d => d.Id == id);

                if (donante == null)
                {
                    Console.WriteLine("Donante no encontrado.");
                    return;
                }

                context.Donante.Remove(donante);
                Console.WriteLine("Donante eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar donante: {ex.Message}");
            }
        }
    }
}
