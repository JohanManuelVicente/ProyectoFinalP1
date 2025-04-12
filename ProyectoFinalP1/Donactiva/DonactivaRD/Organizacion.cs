using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DonactivaRD
{
    public class Organizacion
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }
        [MaxLength(100)]
        public string? Tipo { get; set; }
        [MaxLength(100)]
        public string? RNC { get; set; }
        [MaxLength(200)]
        public string? Direccion { get; set; }
        [MaxLength(150)]
        public string? Contacto { get; set; }
     
        public string? Correo { get; set; }
    }
}
