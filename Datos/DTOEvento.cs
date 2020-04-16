using System;

public class DTOEvento
{
    public int IdEvento;
    public int IdMercado;
    public string Nombre;
    public string nombreEvento;
    

    public DTOEvento(int Idevento, int Idmercado, string nombre,string nombreevento)
    {
        this.IdEvento = Idevento;
        this.IdMercado = Idmercado;
        this.Nombre = nombre;
        this.nombreEvento = nombreevento;


    }

    public DTOEvento()
    {
    }

    public float GetIdEventoDTO()
    {
        return this.IdEvento;
    }
    public void SetIdEventoDTO(int Idevento)
    {
        this.IdEvento = Idevento;
    }
    public int GetIdMercadoDTO()
    {
        return this.IdMercado;
    }
    public void SetIdMercadoDTO(int Idmercado)
    {
        this.IdMercado = Idmercado;
    }
    public string GetNombreDTO()
    {
        return this.Nombre;
    }
    public void SetNombreDTO(string nombre)
    {
        this.Nombre = nombre;
    }
    public string GetNombreEventoDTO()
    {
        return this.nombreEvento;
    }
    public void SetNombreEventoDTO(string nombreevento)
    {
        this.nombreEvento = nombreevento;
    }

}
