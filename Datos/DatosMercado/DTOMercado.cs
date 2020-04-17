using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DatosMercado
{
    public class DTOMercado
    {
        public int IdMercado { get; set; }
        public string Nombre { get; set; }
        public float Couta { get; set; }

        public DTOMercado()
        {

        }

        public DTOMercado(string nombre, int cuota)
        {
            Nombre = nombre;
            Couta = cuota;
        }
    }
}
