using System;
using System.Collections.Generic;

public interface IDAOEvento
{
    DTOEvento CrearEventoDAO(DTOEvento eventoDTO);

    DTOEvento RecuperarEventoDAO(int id);

    //DTOEvento RecuperarNombreEventoDAO(string nombreevento);

    List<DTOEvento> RecuperarListaEvento();


}  
