﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonactivaRD
{
    public class DonanteService : IDonanteService
    {
        public void AgregarDonante()
        {
            try
            {
                var context = new DonactivaRD_DataContext();
                Donante nuevo = new Donante();

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
                context.SaveChanges();

                Console.WriteLine("Donante agregado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar donante: {ex.Message}");
            }
        }

        public void EditarDonante(int id)
        {
            try
            {
                var context = new DonactivaRD_DataContext();
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

                context.Donante.Update(donante);
                context.SaveChanges();

                Console.WriteLine("Donante editado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar donante: {ex.Message}");
            }
        }

        public void ListarDonantes()
        {
            var context = new DonactivaRD_DataContext();

            if (!context.Donante.Any())
            {
                Console.WriteLine("No hay donantes registrados.");
                return;
            }

            foreach (var d in context.Donante)
            {
                Console.WriteLine($"ID: {d.Id}\tNombre: {d.Nombre}\tCorreo: {d.Correo}\tTeléfono: {d.Telefono}\tTipo: {d.Tipo}");
            }
        }

        public void BuscarDonante(string criterio)
        {
            var context = new DonactivaRD_DataContext();

            try
            {
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

        public void EliminarDonante(int id)
        {
            try
            {
                var context = new DonactivaRD_DataContext();
                var donante = context.Donante.FirstOrDefault(d => d.Id == id);

                if (donante == null)
                {
                    Console.WriteLine("Donante no encontrado.");
                    return;
                }

                context.Donante.Remove(donante);
                context.SaveChanges();

                Console.WriteLine("Donante eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar donante: {ex.Message}");
            }
        }
    }
}