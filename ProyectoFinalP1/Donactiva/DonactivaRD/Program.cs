using DonactivaRD;

bool continuar = true;
int opcionSeleccionada = 0;
var context = new DonactivaRD_DataContext();

// Instancia de los servicios
IDonanteService donanteService = new DonanteService();

List<Donante> donantes = context.Donante.ToList();
List<Organizacion> organizaciones = context.Organizacion.ToList();
List<Campaña> campañas = context.Campaña.ToList();
List<Donacion> donaciones = context.Donacion.ToList();

Console.WriteLine("Bienvenido a DonactivaRD - Sistema de Gestión de Donaciones");

while (continuar)
{
    try
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("========= MENÚ PRINCIPAL =========");
        Console.WriteLine("1. Gestionar Donantes");
        Console.WriteLine("2. Gestionar Organizaciones");
        Console.WriteLine("3. Gestionar Campañas");
        Console.WriteLine("4. Gestionar Donaciones");
        Console.WriteLine("5. Salir");
        Console.WriteLine("==================================");
        Console.Write("Seleccione una opción: ");

        opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        switch (opcionSeleccionada)
        {
            case 1:
                MenuDonantes(donanteService);
                break;

            case 2:
                try
                {
                    var organizacionHelper = new OrganizacionHelper();
                    organizacionHelper.Menu();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al gestionar organizaciones: {ex.Message}");
                }
                break;

            case 3:
                try
                {
                    CampañaHelper.MenuCampañas();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al gestionar campañas: {ex.Message}");
                }
                break;

            case 4:
                try
                {
                    DonacionHelper.MenuDonaciones(donantes, organizaciones, campañas);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al gestionar donaciones: {ex.Message}");
                }
                break;

            case 5:
                continuar = false;
                break;

            default:
                Console.WriteLine("Opción inválida. Intente de nuevo.");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Entrada inválida. Por favor, ingrese un número.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
    }
}

Console.WriteLine("Gracias por usar DonactivaRD.");
Console.WriteLine();


// ----------------- Menú de Donantes utilizando el servicio -----------------
static void MenuDonantes(IDonanteService donanteService)
{
    bool volver = false;

    while (!volver)
    {
        Console.WriteLine("\n--- Menú Donantes ---");
        Console.WriteLine("1. Agregar Donante");
        Console.WriteLine("2. Editar Donante");
        Console.WriteLine("3. Mostrar Donantes");
        Console.WriteLine("4. Buscar Donante");
        Console.WriteLine("5. Eliminar Donante");
        Console.WriteLine("6. Volver al menú principal");

        Console.Write("Seleccione una opción: ");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                donanteService.AgregarDonante();
                break;
            case "2":
                Console.Write("Ingrese el ID del donante a editar: ");
                int idEditar = Convert.ToInt32(Console.ReadLine());
                donanteService.EditarDonante(idEditar);
                break;
            case "3":
                donanteService.ListarDonantes();
                break;
            case "4":
                Console.Write("Ingrese un nombre o cédula para buscar: ");
                string criterio = Console.ReadLine();
                donanteService.BuscarDonante(criterio);
                break;
            case "5":
                Console.Write("Ingrese el ID del donante a eliminar: ");
                int idEliminar = Convert.ToInt32(Console.ReadLine());
                donanteService.EliminarDonante(idEliminar);
                break;
            case "6":
                volver = true;
                break;
            default:
                Console.WriteLine("Opción inválida.");
                break;
        }
    }
}
