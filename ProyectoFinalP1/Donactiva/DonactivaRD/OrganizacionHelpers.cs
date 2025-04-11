﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonactivaRD
{
    public static class OrganizacionHelper
    {
        public static void MenuOrganizaciones(List<Organizacion> organizaciones)
        {
            int opcion = 0;
            bool continuar = true;

            while (continuar)
            {
                try
                {
                    Console.WriteLine("\n--- Menú Organizaciones ---");
                    Console.WriteLine("1. Agregar Organización");
                    Console.WriteLine("2. Editar Organización");
                    Console.WriteLine("3. Mostrar Organizaciones");
                    Console.WriteLine("4. Buscar Organización");
                    Console.WriteLine("5. Eliminar Organización");
                    Console.WriteLine("6. Volver al menú principal");

                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            AgregarOrganizacion(organizaciones);
                            break;
                        case 2:
                            Console.WriteLine("Ingrese el ID de la organización a editar:");
                            int idEditar = Convert.ToInt32(Console.ReadLine());
                            EditarOrganizacion(organizaciones, idEditar);
                            break;
                        case 3:
                            ListarOrganizaciones(organizaciones);
                            break;
                        case 4:
                            Console.WriteLine("Ingrese el nombre o RNC para buscar:");
                            string criterio = Console.ReadLine();
                            BuscarOrganizacion(organizaciones, criterio);
                            break;
                        case 5:
                            Console.WriteLine("Ingrese el ID de la organización a eliminar:");
                            int idEliminar = Convert.ToInt32(Console.ReadLine());
                            EliminarOrganizacion(organizaciones, idEliminar);
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
                    Console.WriteLine("Entrada inválida. Por favor ingrese un número.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error: {ex.Message}");
                }
            }
        }

        public static void AgregarOrganizacion(List<Organizacion> organizaciones)
        {
            try
            {
                Organizacion nueva = new Organizacion();
                nueva.Id = organizaciones.Count + 1;

                Console.WriteLine("Nombre de la organización:");
                nueva.Nombre = Console.ReadLine();

                Console.WriteLine("Tipo (ONG, Fundación, etc.):");
                nueva.Tipo = Console.ReadLine();

                Console.WriteLine("RNC:");
                nueva.RNC = Console.ReadLine();

                Console.WriteLine("Dirección:");
                nueva.Direccion = Console.ReadLine();

                Console.WriteLine("Persona de contacto:");
                nueva.Contacto = Console.ReadLine();

                Console.WriteLine("Correo electrónico:");
                nueva.Correo = Console.ReadLine();

                organizaciones.Add(nueva);
                Console.WriteLine("Organización registrada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar organización: {ex.Message}");
            }
        }

        public static void EditarOrganizacion(List<Organizacion> organizaciones, int id)
        {
            try
            {
                var organizacion = organizaciones.FirstOrDefault(o => o.Id == id);

                if (organizacion == null)
                {
                    Console.WriteLine("Organización no encontrada.");
                    return;
                }

                Console.WriteLine("Editar nombre:");
                organizacion.Nombre = Console.ReadLine();

                Console.WriteLine("Editar tipo:");
                organizacion.Tipo = Console.ReadLine();

                Console.WriteLine("Editar RNC:");
                organizacion.RNC = Console.ReadLine();

                Console.WriteLine("Editar dirección:");
                organizacion.Direccion = Console.ReadLine();

                Console.WriteLine("Editar contacto:");
                organizacion.Contacto = Console.ReadLine();

                Console.WriteLine("Editar correo:");
                organizacion.Correo = Console.ReadLine();

                Console.WriteLine("Organización actualizada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar organización: {ex.Message}");
            }
        }

        public static void ListarOrganizaciones(List<Organizacion> organizaciones)
        {
            if (!organizaciones.Any())
            {
                Console.WriteLine("No hay organizaciones registradas.");
                return;
            }

            Console.WriteLine("ID\tNombre\t\tTipo\t\tRNC\t\tCorreo");
            foreach (var o in organizaciones)
            {
                Console.WriteLine($"{o.Id}\t{o.Nombre}\t\t{o.Tipo}\t\t{o.RNC}\t\t{o.Correo}");
            }
        }

        public static void BuscarOrganizacion(List<Organizacion> organizaciones, string criterio)
        {
            try
            {
                var resultados = organizaciones
                    .Where(o => o.Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase)
                             || o.RNC.Contains(criterio))
                    .ToList();

                if (!resultados.Any())
                {
                    Console.WriteLine("No se encontraron organizaciones.");
                    return;
                }

                Console.WriteLine("Resultados encontrados:");
                foreach (var o in resultados)
                {
                    Console.WriteLine($"ID: {o.Id}, Nombre: {o.Nombre}, RNC: {o.RNC}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en búsqueda: {ex.Message}");
            }
        }

        public static void EliminarOrganizacion(List<Organizacion> organizaciones, int id)
        {
            try
            {
                var organizacion = organizaciones.FirstOrDefault(o => o.Id == id);

                if (organizacion == null)
                {
                    Console.WriteLine("Organización no encontrada.");
                    return;
                }

                organizaciones.Remove(organizacion);
                Console.WriteLine("Organización eliminada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar organización: {ex.Message}");
            }
        }
    }
}
