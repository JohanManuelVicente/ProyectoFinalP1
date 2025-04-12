using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DonactivaRD
{
    public class Campaña
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string? Descripcion { get; set; }
        [MaxLength(100)]
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal? Meta { get; set; }
        public string? Estado { get; set; } // Activa, Finalizada, Cancelada
        
    }
}
