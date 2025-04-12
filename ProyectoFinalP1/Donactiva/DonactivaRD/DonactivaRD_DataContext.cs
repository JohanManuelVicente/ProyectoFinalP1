using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonactivaRD
{
    public class DonactivaRD_DataContext : DbContext
    {
        public DbSet<Donante> Donante { get; set; }
        public DbSet<Organizacion> Organizacion { get; set; }
        public DbSet<Campaña> Campaña { get; set; }
        public DbSet<Donacion> Donacion { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=VICENTE\\SQLEXPRESS;Database=DonactivaRD;Trusted_Connection=True;MulptipleActiveResultSets=true;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
