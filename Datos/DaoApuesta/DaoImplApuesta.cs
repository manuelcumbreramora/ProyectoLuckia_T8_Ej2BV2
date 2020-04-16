﻿using System;
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
        public ApuestaDTO AgregarApuesta(int IdUsuario, float Importe, int IdMercado)
        {
            ApuestaDTO apuesta = new ApuestaDTO(IdUsuario,Importe,IdMercado);
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO Apuesta(Importe,IdUsuario,IdMercado) OUTPUT INSERTED.IdApuesta VALUES(@Importe,@IdUsuario,@IdMercado)";
            cmd.Parameters.AddWithValue("@Importe", apuesta.Importe);
            cmd.Parameters.AddWithValue("@IdUsuario", apuesta.IdUsuario);
            cmd.Parameters.AddWithValue("@IdMercado", apuesta.IdMercado);

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
            cmd.CommandText = "SELECT Importe, IdApuesta, IdMercado FROM Apuesta WHERE IdUsuario=@Id";
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
                        apuesta.IdMercado = reader.GetInt32(2);
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
