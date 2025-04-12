using DonactivaRD;

bool continuar = true;
int opcionSeleccionada = 0;
var context = new DonactivaRD_DataContext();

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
                try
                {
                    DonanteHelper.MenuDonantes();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al gestionar donantes: {ex.Message}");
                }
                break;

            case 2:
                try
                {
                    OrganizacionHelper.MenuOrganizaciones();
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
                    DonacionHelper.MenuDonaciones(donaciones, donantes, organizaciones, campañas);
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





