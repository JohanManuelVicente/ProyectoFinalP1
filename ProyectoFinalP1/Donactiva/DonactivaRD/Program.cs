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
    Console.WriteLine("\nSeleccione una opción:");
    Console.WriteLine("1. Gestionar Donantes");
    Console.WriteLine("2. Gestionar Organizaciones");
    Console.WriteLine("3. Gestionar Donaciones");
    Console.WriteLine("4. Gestionar Campañas");
    Console.WriteLine("5. Salir");

    opcionSeleccionada = Convert.ToInt32(Console.ReadLine());

    switch (opcionSeleccionada)
    {
        case 1:
            DonanteHelper.MenuDonantes(donantes);
            break;
        case 2:
            OrganizacionHelper.MenuOrganizaciones(organizaciones);
            break;
        case 3:
            DonacionHelper.MenuDonaciones(donaciones, donantes, organizaciones, campañas);
            break;
        case 4:
            CampañaHelper.MenuCampañas(campañas);
            break;
        case 5:
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            break;
    }
}

Console.WriteLine("Gracias por usar DonactivaRD.");


    
