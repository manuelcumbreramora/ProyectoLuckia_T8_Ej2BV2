using System;
using System.Data.SqlClient;

public class DaoImplEvento : IDAOEvento
{
            public Conexion conexion;
            public string error;

            public DaoImplEvento()
            {
                conexion = new Conexion();
            }
    public DTOEvento CrearEventoDAO(DTOEvento eventoDTO)
    {
        int idIngresado = 0;
        SqlConnection conexion;
        conexion = new SqlConnection(this.conexion.GetNombreConexion());
        conexion.Open();
        SqlCommand comando = new SqlCommand();
        comando.Connection = conexion;

        String consulta = "INSERT INTO Evento(IdEvento,IdMercado,Nombre) OUTPUT INSERTED.IdEvento VALUES(" + eventoDTO.GetIdEventoDTO() + ", " + eventoDTO.GetIdMercadoDTO() + ", '" + eventoDTO.GetNombreDTO() + "')";
        comando.CommandText = consulta;

        try
        {
            SqlDataReader registro = comando.ExecuteReader();

            if (registro.Read())
            {
                idIngresado = registro.GetInt32(0);
                eventoDTO.SetIdEventoDTO(idIngresado);
                registro.Close();
                conexion.Close();
                return eventoDTO;
            }
        }
        catch (SqlException ex)
        {
            this.error = ex.Message;
            Console.WriteLine("Error " + this.error);
            Console.ReadLine();
        }

        conexion.Close();
        return null;

    }

    public DTOEvento RecuperarEventoDAO(int id)
    {
        DTOEvento monedero = new DTOEvento();
        SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
        connection.Open();
        SqlCommand comando = new SqlCommand();
        comando.Connection = connection;
        String consulta = "SELECT IdEvento,IdMercado,Nombre, FROM Evento WHERE IdEvento=" + id + ";";
        comando.CommandText = consulta;
        
        SqlDataReader registro = comando.ExecuteReader();
        if (registro.Read())
        {
            DTOEvento nuevoEvento = new DTOEvento();
            nuevoEvento.SetIdEventoDTO(registro.GetInt32(0));
            nuevoEvento.SetIdMercadoDTO(registro.GetInt32(1));
            nuevoEvento.SetNombreDTO(registro.GetString(2));
            int i = registro.GetInt32(3);
            nuevoEvento.SetIdEventoDTO(i);

            registro.Close();
            connection.Close();
            return nuevoEvento;
        }
        else
        {
            registro.Close();
            connection.Close();
            return null;
        }

    }

    public DTOEvento RecuperarNombreEventoDAO(string nombreevento)
    {
        DTOEvento monederonombre = new DTOEvento();
        SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
        connection.Open();
        SqlCommand comando = new SqlCommand();
        comando.Connection = connection;
        String consulta = "SELECT Nombre,NombreEvento FROM Evento WHERE NombreEvento=" + nombreevento + ";";
        comando.CommandText = consulta;

        SqlDataReader registro = comando.ExecuteReader();
        if (registro.Read())
        {
            DTOEvento nuevoEvento = new DTOEvento();
            nuevoEvento.SetIdEventoDTO(registro.GetInt32(0));
            nuevoEvento.SetIdMercadoDTO(registro.GetInt32(1));
            nuevoEvento.SetNombreDTO(registro.GetString(2));
            nuevoEvento.SetNombreEventoDTO(registro.GetString(3));
            nuevoEvento.SetNombreEventoDTO(nombreevento);

            registro.Close();
            connection.Close();
            return nuevoEvento;
        }
        else
        {
            registro.Close();
            connection.Close();
            return null;
        }
    }
}

