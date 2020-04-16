using System;

public interface IDAOEvento
{
    DTOEvento CrearEventoDAO(DTOEvento eventoDTO);

    DTOEvento RecuperarEventoDAO(int id);

    DTOEvento RecuperarNombreEventoDAO(string nombreevento);

    // bool ModificarSaldoMonederoDTO(int idMonederoAmodificar, float saldoNuevo);

    // DTOMonedero RecuperarMonederoPorIdUsuarioDAO(int idUsuario);
}
