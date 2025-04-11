using DonactivaRD;

List<Donante> donantes = new List<Donante>();
List<Organizacion> organizaciones = new List<Organizacion>();
List<Donacion> donaciones = new List<Donacion>();
List<Campaña> campañas = new List<Campaña>();

bool continuar = true;
int opcionSeleccionada = 0;

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
        Console.WriteLine("3. Gestionar Donaciones");
        Console.WriteLine("4. Gestionar Campañas");
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
                    DonanteHelper.MenuDonantes(donantes);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al gestionar donantes: {ex.Message}");
                }
                break;

            case 2:
                try
                {
                    OrganizacionHelper.MenuOrganizaciones(organizaciones);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al gestionar organizaciones: {ex.Message}");
                }
                break;

            case 3:
                try
                {
                    DonacionHelper.MenuDonaciones(donaciones, donantes, organizaciones, campañas);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al gestionar donaciones: {ex.Message}");
                }
                break;

            case 4:
                try
                {
                    CampañaHelper.MenuCampañas(campañas);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al gestionar campañas: {ex.Message}");
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




