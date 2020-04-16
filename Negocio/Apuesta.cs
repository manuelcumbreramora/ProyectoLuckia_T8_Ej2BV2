using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Apuesta
    {
        private int IdApuesta;
        public int GetIdApuesta()
        {
            return this.IdApuesta;
        }
        public void SetIdApuesta(int id)
        {
            this.IdApuesta = id;
        }
        private float Importe;
        public float GetImporte()
        {
            return this.Importe;
        }
        public void SetImporte(float Importe)
        {
            this.Importe = Importe;
        }
        private int IdUsuario;
        public int GetIdUsuario()
        {
            return this.IdUsuario;
        }
        public void SetIdUsuario(int id)
        {
            this.IdUsuario = id;
        }
        private int IdEvento;
        public int GetIdEvento()
        {
            return this.IdEvento;
        }
        public void SetIdEvento(int id)
        {
            this.IdEvento = id;
        }
        public Apuesta(int idApuesta, int idUsuario, float importe, int idEvento)
        {
            IdApuesta = idApuesta;
            Importe = importe;
            IdUsuario = idUsuario;
            IdEvento = idEvento;
        }

        public Apuesta()
        {
        }
    }
}
