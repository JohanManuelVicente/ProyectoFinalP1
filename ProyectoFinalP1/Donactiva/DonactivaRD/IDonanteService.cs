using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonactivaRD
{
    public interface IDonanteService
    {
        void AgregarDonante();
        void EditarDonante(int id);
        void ListarDonantes();
        void BuscarDonante(string criterio);
        void EliminarDonante(int id);
    }
}
