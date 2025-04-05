using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonactivaRD
{
    public class Donacion
    {
        public int Id { get; set; }
        public string Tipo { get; set; } // Monetaria, Especie o de Tiempo
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int DonanteId { get; set; }
        public int OrganizacionId { get; set; }
        public int? CampañaId { get; set; }
    }
}
