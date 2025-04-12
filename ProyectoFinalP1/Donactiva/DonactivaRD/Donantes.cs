using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DonactivaRD
{
    public class Donante
    {
        [Key]
        public int Id { get; set; }
      
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Correo { get; set; }
        [MaxLength(150)]
        public string Telefono { get; set; }
        [MaxLength(100)]
        public string Cedula { get; set; }
        [MaxLength(150)]
        public string Direccion { get; set; }
        [MaxLength(150)]
        public string Tipo { get; set; } // Individual o Empresa
        
    }
}
