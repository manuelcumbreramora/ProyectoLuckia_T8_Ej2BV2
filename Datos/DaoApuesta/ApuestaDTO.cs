using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DaoApuesta
{
    public class ApuestaDTO
    {
        public int? IdApuesta { get; set; }
        public float Importe { get; set; }
        public int IdUsuario { get; set; }
        public int IdMercado { get; set; }
        public ApuestaDTO()
        {
        }

        public ApuestaDTO(int idApuesta, float importe, int idUsuario, int idMercado)
        {
            IdApuesta = idApuesta;
            Importe = importe;
            IdUsuario = idUsuario;
            IdMercado = idMercado;
        }
        public ApuestaDTO( int idUsuario,float importe, int idMercado)
        {
            Importe = importe;
            IdUsuario = idUsuario;
            IdMercado = idMercado;
        }


    }
}
