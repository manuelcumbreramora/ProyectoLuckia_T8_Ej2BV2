using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos.DatosMercado
{
    public class DaoImplMercado : IDAOMercado
    {
        public Conexion conexion;
        public SqlTransaction sqlTransaction;

        public DaoImplMercado()
        {
            conexion = new Conexion();
        }

        public DTOMercado CrearMercadoDAO(DTOMercado mercado)
        {
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "";
            cmd.Parameters.AddWithValue("@Nombre", mercado.Nombre);
            cmd.Parameters.AddWithValue("@Cuota", mercado.Couta);
            cmd.Parameters.AddWithValue("@FechaCreacion", mercado.FechaCreacion);

            try
            {
                cmd.ExecuteNonQuery();
                connection.Close();
                return mercado;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }

        public DTOMercado ModificarNombreMercado(int idMercado, string nombreMercado)
        {
            DTOMercado mercado = new DTOMercado();
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "";

            try
            {
                return mercado;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }

        public DTOMercado ModificarCuotaMercado(int idMercado, float cuotaMercado)
        {
            DTOMercado mercado = new DTOMercado();
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "";

            try
            {
                return mercado;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }

        public DTOMercado RecuperarMercadoPorIdMercadoDAO(int id)
        {
            DTOMercado mercado = new DTOMercado();
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "";
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        mercado.IdMercado = id;
                        mercado.Nombre = reader.GetString(0);
                        mercado.Couta = reader.GetFloat(1);
                        mercado.FechaCreacion = reader.GetDateTime(2);

                    }
                }
                reader.Close();
                connection.Close();
                return mercado;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }
    }
}
