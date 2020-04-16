using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DaoApuesta
{    
    public class DaoImplApuesta : IDAOApuesta
    {
        public Conexion conexion;
        public SqlTransaction sqlTransaction;

        public DaoImplApuesta()
        {
            conexion = new Conexion();
        }
        public ApuestaDTO AgregarApuesta(int IdUsuario, float Importe, int IdEvento)
        {
            ApuestaDTO apuesta = new ApuestaDTO(IdUsuario,Importe,IdEvento);
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO Apuesta(Importe,IdUsuario,IdEvento) OUTPUT INSERTED.IdApuesta VALUES(@Importe,@IdUsuario,@IdEvento)";
            cmd.Parameters.AddWithValue("@Importe", apuesta.Importe);
            cmd.Parameters.AddWithValue("@IdUsuario", apuesta.IdUsuario);
            cmd.Parameters.AddWithValue("@IdEvento", apuesta.IdEvento);

            try
            {
                int? result = (int?)cmd.ExecuteScalar();
                apuesta.IdApuesta=result;
                connection.Close();
                return apuesta;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }

        public List<ApuestaDTO> RecuperarListaApuestasPorIdJugador(int IdJugador)
        {
            List<ApuestaDTO> listaApuestas = new List<ApuestaDTO>();
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT Importe, IdApuesta, IdEvento FROM Apuesta WHERE IdUsuario=@Id";
            cmd.Parameters.AddWithValue("@Id", IdJugador);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        ApuestaDTO apuesta = new ApuestaDTO();
                        apuesta.Importe = (float)reader.GetDouble(0);
                        apuesta.IdApuesta = reader.GetInt32(1);
                        apuesta.IdEvento = reader.GetInt32(2);
                        apuesta.IdUsuario = IdJugador;
                        listaApuestas.Add(apuesta);
                    }
                }
                reader.Close();
                connection.Close();
                return listaApuestas;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }
    }
}
