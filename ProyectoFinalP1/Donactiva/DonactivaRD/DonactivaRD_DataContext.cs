using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonactivaRD
{
    public class DonactivaRD_DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=VICENTE\\SQLEXPRESS;Database=DonactivaRD;Trusted_Connection=True;MulptipleActiveResultSets=true;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
