using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DaoApuesta
{
    public interface IDAOApuesta
    {
        List<ApuestaDTO> RecuperarListaApuestasPorIdJugador(int IdJugador);

        ApuestaDTO AgregarApuesta(int IdUsuario, float Importe, int IdEvento);

    }
}
