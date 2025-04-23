using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonactivaRD
{
    public abstract class BaseHelper
    {
        // Método común disponible para todas las clases que hereden
        protected void MostrarError(string mensaje)
        {
            Console.WriteLine($"❌ Error: {mensaje}");
        }

        // Método abstracto obligatorio
        public abstract void Menu();
    }
}
