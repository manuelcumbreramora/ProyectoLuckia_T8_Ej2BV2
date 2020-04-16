using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Sistema
    {
        private DaoImplMercado conexionDaoMercado;
        private DaoImplApuesta conexionDaoApuesta;
        private DaoImplEvento conexionDaoEvento;
        public Sistema()
        {
            conexionDaoMercado = new DaoImplMercado();
            conexionDaoApuesta = new DaoImplApuesta();
            conexionDaoEvento = new DaoImplEvento();
        }
        public Apuesta InsertarApuesta(int idUsuario, float importe, int idMercado)
        {
            ApuestaDTO apuesta = new ApuestaDTO(idUsuario, importe, idMercado);
            apuesta = conexionDaoApuesta.AgregarApuesta(apuesta);
            if (apuesta.id != null)
            {
                Apuesta result = new Apuesta(apuesta.id.GetValueOrDefault(), apuesta.idUsuario, apuesta.importe, apuesta.idMercado);
                return result;
            }
            return null;

        }

        public List<Apuesta> RecuperarListaApuestasPorIdJugador(int idJugador)
        {
            List<ApuestaDTO> listaApuestasDTO = conexionDaoApuesta.RecuperarListaApuestasPorIdJugador(idJugador);
            List<Apuesta> listaApuestas = new List<Apuesta>();

            foreach (ApuestaDTO oDTO in listaApuestasDTO)
            {
                Apuesta nuevaApuesta = new Apuesta(oDTO.idApuesta, oDTO.idUsuario, oDTO.importe, oDTO.idEvento);

                listaApuestas.Add(nuevaApuesta);
            }
            return listaApuestas;

        }

        public List<Evento> RecuperarEventos(int idEvento)
        {
            List<DTOEvento> listaEventosDTO = conexionDaoEvento.RecuperarEventos(idEvento);
            List<Evento> listaEventos = new List<Evento>();

            foreach (DTOEvento oDTO in listaEventosDTO)
            {
                Evento nuevoEvento = new Evento(oDTO.idEvento, oDTO.nombre, oDTO.idMercado);

                listaEventos.Add(nuevoEvento);
            }
            return listaEventos;

        }

        public Evento RecuperarEvento(int idEvento)
        {
            DTOEvento eventoDTO = this.conexionDaoEvento.RecuperarEvento(idEvento);
            if (eventoDTO != null)
            {
                Evento nuevoEvento = new Evento(eventoDTO.idEvento, eventoDTO.nombre, eventoDTO.idMercado);
                return nuevoEvento;
            }
            else
            {
                return null;
            }

        }

        public Evento RecuperarEventoPorNombreEvento(string nombre)
        {
            DTOEvento eventoDTO = this.conexionDaoEvento.RecuperarEventoPorNombreEvento(nombre);
            if (eventoDTO != null)
            {
                Evento nuevoEvento = new Evento(eventoDTO.idEvento, eventoDTO.nombre, eventoDTO.idMercado);
                return nuevoEvento;
            }
            else
            {
                return null;
            }

        }

        public Mercado RecuperarMercado(int idMercado)
        {
            DTOMercado mercadoDTO = this.conexionDaoMercado.RecuperarMercado(idMercado);
            if (mercadoDTO != null)
            {
                Mercado nuevoMercado = new Mercado(mercadoDTO.idMercado, mercadoDTO.nombre, mercadoDTO.cuota, mercadoDTO.idMercado);
                return nuevoMercado;
            }
            else
            {
                return null;
            }

        }

        public string ModificarEvento(int idEvento, string nombreEvento, string nombreMercado)
        {
            DTOEvento modEventoDTO, modEventoDTO2;
            if (nombreEvento != "" && nombreMercado != "")
            {
                modEventoDTO = conexionDaoEvento.ModificarNombreEvento(idEvento, nombreEvento);
                if (modEventoDTO != null)
                {
                    conexionDaoMercado.ModificarNombreMercado(modEventoDTO.idMercado);
                }
            }
            else if (nombreEvento != "" && nombreMercado == "")
            {
                modEventoDTO = conexionDaoEvento.ModificarNombreEvento(idEvento, nombreEvento);
            }else if (nombreEvento == "" && nombreMercado != "")
            {
                modEventoDTO = conexionDaoMercado.ModificarNombreMercado(idEvento, nombreMercado);
            }

            if (modEventoDTO != null || modEventoDTO2 != null)
            {
                return "El evento " + modEventoDTO.nombre + " ha sido modificado";
            }
            else
            {
                return "Error al modificar el evento " + nombreEvento;
            }
        }

        public string ModificarCuota(int idMercado, float cuota, string nombreMercado)
        {
            DTOMercado mercadoDTO;
            if (nombreMercado != "" && cuota > 0)
            {
                mercadoDTO = conexionDaoMercado.ModificarNombreMercado(idMercado, nombreMercado);
                conexionDaoMercado.ModificarCuota(mercadoDTO.idMercado, cuota);
            }
            else if (nombreMercado != "" && (cuota == 0 || cuota.Equals(null)))
            { 
                mercadoDTO = conexionDaoMercado.ModificarNombreMercado(idMercado, nombreMercado);
            }
            else if (nombreMercado == "" && cuota > 0)
            {
                mercadoDTO = conexionDaoMercado.ModificarCuota(idMercado, cuota);
            }

            if (mercadoDTO != null)
            {
                return "El mercado " + mercadoDTO.nombre + " ha sido modificado";
            }
            else
            {
                return "Error al modificar el evento " + nombreMercado;
            }
        }

        public Mercado RecuperarMercadoPorNombre(string nombreMercado)
        {
            DTOMercado mercadoDTO = this.conexionDaoMercado.RecuperarMercadoPorNombre(nombreMercado);
            if (mercadoDTO != null)
            {
                Mercado nuevoMercado = new Mercado(mercadoDTO.idMercado, mercadoDTO.nombre, mercadoDTO.cuota, mercadoDTO.idMercado);
                return nuevoMercado;
            }
            else
            {
                return null;
            }

        }
    }
}
