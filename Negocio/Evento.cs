using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Evento
    {
        public int IdEvento;
        public int IdMercado;
        public string Nombre;
        public string nombreEvento;
    

    public Evento(int Idevento, int Idmercado, string nombre,string nombreevento)
    {
        this.IdEvento = Idevento;
        this.IdMercado = Idmercado;
        this.Nombre = nombre;
        this.nombreEvento = nombreevento;


    }

    public Evento()
    {
    }

    public float IdEventoDTO()
    {
        return this.IdEvento;
    }
    public void SetIdEvento(int Idevento)
    {
        this.IdEvento = Idevento;
    }
    public int GetIdMercado()
    {
        return this.IdMercado;
    }
    public void SetIdMercado(int Idmercado)
    {
        this.IdMercado = Idmercado;
    }
    public string GetNombreO()
    {
        return this.Nombre;
    }
    public void SetNombre(string nombre)
    {
        this.Nombre = nombre;
    }
    public string GetNombreEvento()
    {
        return this.nombreEvento;
    }
    public void SetNombreEvento(string nombreevento)
    {
        this.nombreEvento = nombreevento;
    }

    }
}
