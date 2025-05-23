﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonactivaRD
{
    public static class DonacionHelper
    {
        public static void MenuDonaciones( List<Donante> donantes, List<Organizacion> organizaciones, List<Campaña> campañas)
        {
            var context = new DonactivaRD_DataContext();
            var donaciones = context.Donacion.ToList();

       
            int opcion = 0;
            bool continuar = true;

            while (continuar)
            {
                try
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
                            RegistrarDonacion( donantes, organizaciones, campañas, new DonanteService());
                            break;
                        case 2:
                            ListarDonaciones();
                            break;
                        case 3:
                            Console.WriteLine("Ingrese nombre o cédula del donante:");
                            string criterio = Console.ReadLine();
                            BuscarDonacionesPorDonante( donantes, criterio);
                            break;
                        case 4:
                            Console.WriteLine("Ingrese el ID de la donación a eliminar:");
                            int idEliminar = Convert.ToInt32(Console.ReadLine());
                            EliminarDonacion( idEliminar);
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

        public static void RegistrarDonacion(
     List<Donante> donantes,
     List<Organizacion> organizaciones,
     List<Campaña> campañas,
     IDonanteService donanteService)
        {
            var context = new DonactivaRD_DataContext();

            try
            {
                if (!donantes.Any())
                {
                    Console.WriteLine("No hay donantes registrados. Debe registrar al menos uno antes de continuar.");
                    return;
                }

                if (!organizaciones.Any())
                {
                    Console.WriteLine("No hay organizaciones registradas. Debe registrar al menos una antes de continuar.");
                    return;
                }

                if (!campañas.Any())
                {
                    Console.WriteLine("No hay campañas registradas. Debe registrar al menos una antes de continuar.");
                    return;
                }

                Donacion nueva = new Donacion();

                Console.WriteLine("Ingrese el ID del Donante:");
                donanteService.ListarDonantes(); // <-- ahora correcto
                nueva.DonanteId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el ID de la Organización receptora:");
                var organizacionHelper = new OrganizacionHelper();
                organizacionHelper.ListarOrganizaciones();
                nueva.OrganizacionId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el ID de la Campaña asociada:");
                CampañaHelper.ListarCampañas();
                nueva.CampañaId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el tipo de donación (dinero, alimento, etc.):");
                nueva.Tipo = Console.ReadLine();

                Console.WriteLine("Ingrese el monto o descripción:");
                nueva.Descripcion = Console.ReadLine();

                Console.WriteLine("Fecha de la donación (YYYY-MM-DD):");
                nueva.Fecha = DateTime.Parse(Console.ReadLine());

                context.Donacion.Add(nueva);
                context.SaveChanges();
                Console.WriteLine("Donación registrada exitosamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido. Asegúrese de ingresar números y fechas correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar donación: {ex.Message}");
            }
        }


        public static void ListarDonaciones()
        {
            var context = new DonactivaRD_DataContext();
            var donaciones = context.Donacion.ToList();

            if (!donaciones.Any())
            {
                Console.WriteLine("No hay donaciones registradas.");
                return;
            }

            Console.WriteLine();
            foreach (var d in donaciones)
            { 
                Console.WriteLine($"ID: {d.Id}\tDonanteID: {d.DonanteId}\tOrganizacionID: {d.OrganizacionId}\tCampañaID: {d.CampañaId}\tTipo: {d.Tipo}\tMonto/Descripción: {d.Descripcion}\tFecha: {d.Fecha.ToShortDateString()}");
            }
        }

        public static void BuscarDonacionesPorDonante( List<Donante> donantes, string criterio)
        {
            var context = new DonactivaRD_DataContext();
            var donaciones = context.Donacion.ToList();

            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar donaciones: {ex.Message}");
            }
        }

        public static void EliminarDonacion( int id)
        {
            var context = new DonactivaRD_DataContext();
            Donacion nueva = new Donacion();


            try
            {
                var donacion = context.Donacion.FirstOrDefault(d => d.Id == id);

                if (donacion == null)
                {
                    Console.WriteLine("Donación no encontrada.");
                    return;
                }

                context.Donacion.Remove(donacion);
                context.SaveChanges();
                Console.WriteLine("Donación eliminada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar donación: {ex.Message}");
            }
        }
    }
}
