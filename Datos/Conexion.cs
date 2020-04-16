using System;

public class Conexion
{
    private String NombreConexion;

    public Conexion()
    {
        NombreConexion = "Data Source=PLX300000000411\\SQLEXPRESS;Initial Catalog=Tema8_Ej2A;Integrated Security=True";
    }

    public string GetNombreConexion()
    {
        return this.NombreConexion;
    }
}
