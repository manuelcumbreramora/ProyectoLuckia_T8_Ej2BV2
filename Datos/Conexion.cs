using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        private String NombreConexion;

        public Conexion()
        {
            NombreConexion = @"server=PLX300000000415\SQLEXPRESS; database=Tema8_Ej2A; integrated security=true";
        }

        public string GetNombreConexion()
        {
            return this.NombreConexion;
        }
    }
}
