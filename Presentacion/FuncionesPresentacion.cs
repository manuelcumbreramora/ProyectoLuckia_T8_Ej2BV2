using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class FuncionesPresentacion
    {
        Sistema sistemaCentral;
        public FuncionesPresentacion()
        {
            sistemaCentral = new Sistema();
        }

        public void VisualizarApuestas(int idJugador)
        {
            Console.Clear();
            List<Apuesta> listaApuestas = sistemaCentral.RecuperarListaApuestasPorIdJugador();
            if (listaApuestas != null) {
                Console.WriteLine("Mostramos las apuestas del jugador con Id: " + idJugador);
            foreach (Apuesta apuesta in listaApuestas)
            {
                Mercado mercado = sistemaCentral.RecuperarMercado(apuesta.GetIdEvento());
                Console.WriteLine("Id Apuesta: " + apuesta.GetIdApuesta() + " del Usuario con Id : " + apuesta.GetIdUsuario() + " ha apostado un importe de : " + apuesta.GetImporte() + " en el mercado: " + mercado.GetNombre());
            }
            }
            else{
                Console.WriteLine("No hay apuestas para este jugador");
            }

            Console.ReadLine();

        }
        public void VisualizarEventosCuotasMercados()
        {
            Console.Clear();
            List<Evento> listaEventos = sistemaCentral.RecuperarEventos();
            
            if(listaEventos!= null)
            {
               foreach(Evento evento in listaEventos)
                {
                    Mercado nuevoMercado = sistemaCentral.RecuperarMercado(evento.GetIdMercado());

                    if (nuevoMercado != null) {
                        
                    Console.WriteLine(". Evento con id :"+evento.GetIdEvento()+" y con nombre : " + evento.GetNombre() + "en el mercado con Id : " + mercado.GetIdMercado() + " y nombre : " + mercado.GetNombre() + " se estableció una cuota de  " + mercado.GetCuota());

                    }
                    else
                    {
                        Console.WriteLine("No esta el mercado disponible");
                    }

                }
            }
            else
            {
                Console.WriteLine("No hay eventos disponible");
            }
        }

        public void RealizarApuesta(int idJugador)
        {
            Console.Clear();
            String cadenaImporte;
            String cadenaIdMercado;
            float importe;
            int idMercado;
            Console.WriteLine("Hola Jugador:" + idJugador);
            this.VisualizarEventosCuotasMercados();
            /*
             Dame un ID de mercado de los eventos mostrados para realizar una apuesta,  recoger idMercado

            Cuanto desea Apostar? recoeger importe

            
             */
            Console.WriteLine("  Dame un ID de mercado de los eventos mostrados para realizar una apuesta:");
            cadenaIdMercado = Console.ReadLine();

            Console.WriteLine("  Cuanto quiere apostar ");
            cadenaImporte = Console.ReadLine();

            idMercado = Int32.Parse(cadenaIdMercado);
            importe = float.Parse(cadenaImporte);

            Apuesta nuevaApuesta = this.sistemaCentral.insertarApuesta(idJugador, importe, idMercado);

            if (nuevaApuesta != null)
            {
                Console.WriteLine("La apuesta se ha realizado con exito");
            }
            else
            {
                Console.WriteLine("La apuesta no se ha podido realizar");
            }
        }

            public void Inicio(int idJugador)
            {
            Console.Clear();
            String seleccion;
            int numSeleccion=0;
            int salir = 0;
            Console.WriteLine("Hola Jugador:" + idJugador);
            Console.WriteLine("Seleccione una opcion");
            Console.WriteLine("1.Visualizar Eventos con sus mercados y cuotas");
            Console.WriteLine("2.Realizar Apuesta");
            Console.WriteLine("3.Consultar Historial de Apuestas");
            Console.WriteLine("4.Modificar Evento, mercado y cuotas");
            Console.WriteLine("5.Salir");
           seleccion= Console.ReadLine();
            numSeleccion = Int32.Parse(seleccion);
            while (salir != 1)
            {
                switch (numSeleccion)
                {
                    case 1:
                        VisualizarEventosCuotasMercados();
                        Console.ReadLine();
                        break;
                    case 2:
                        RealizarApuesta(idJugador);
                        Console.ReadLine();
                        break;
                    case 3:
                        VisualizarApuestas(idJugador);
                        Console.ReadLine();
                        break;
                    case 4:
                        ModificarEventosMercadosCuotas(idJugador);
                        Console.ReadLine();
                        break;
                    case 5:
                        salir = 1;
                        break;
                    default:
                        Console.WriteLine("Opcion NO correcta");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public void ModificarEventosMercadosCuotas(int idJugador)
        {
            String seleccion;
            int numSeleccion = 0;
            Console.Clear();
            
            
            Console.WriteLine("Seleccione que desea modificar:");
            Console.WriteLine("1.Modificar Nombre Evento");
            Console.WriteLine("2.Modificar Nombre Mercado ");
            Console.WriteLine("3.Modificar Nombre de Mercado y cuota");
            Console.WriteLine("4.Modificar cuota de Mercado");
            Console.WriteLine("5.Salir");
            seleccion = Console.ReadLine();
            numSeleccion = Int32.Parse(seleccion);

            switch (numSeleccion)
            {
                case 1:
                    ModificarNombreEvento(idJugador);
                    VisualizarEventosCuotasMercados();
                    Console.ReadLine();
                    break;
                case 2:
                    ModificarNombreCuotaMercado(idJugador, numSeleccion);
                    VisualizarEventosCuotasMercados();
                    Console.ReadLine();
                    break;
                case 3:
                    ModificarNombreCuotaMercado(idJugador, numSeleccion);
                    VisualizarEventosCuotasMercados();
                    Console.ReadLine();
                    break;
                case 4:
                    ModificarNombreCuotaMercado(idJugador, numSeleccion);
                    VisualizarEventosCuotasMercados();
                    Console.ReadLine();
                    break;
                case 5:
                  
                    break;
                default:
                    
                    break;
            }

            
        }

        public void ModificarNombreEvento(int idJugador)
        {
            String cadenaIdEvento;
            int numIdEvento;
           String cadenaNombreEvento;
            Console.Clear();
            VisualizarEventosCuotasMercados();

            Console.WriteLine("Dame el Id del Evento que desea modificar:");
            cadenaIdEvento=Console.ReadLine();
            numIdEvento = Int32.Parse(cadenaIdEvento);

            Console.WriteLine("Dame el nuevo nombre del evento:");
            cadenaNombreEvento = Console.ReadLine();

            //sistema.ModificarEventos
        }

        public void ModificarNombreCuotaMercado(int idJugador, int opcion)
        {
           
            String cadenaIdMercado;
            int numIdMercado;
            String cadenaNombreMercado;
            String cadenaCuota;
            float cuota;

            Console.WriteLine("Dame el Id del Mercado que desea modificar:");
            cadenaIdMercado = Console.ReadLine();
            numIdMercado = Int32.Parse(cadenaIdMercado);
       
            switch (opcion)
            {
                case 2:
                    Console.WriteLine("Dame el nuevo nombre del mercado:");
                    cadenaNombreMercado = Console.ReadLine();
                    //funcion modificar
                    break;
                case 3:
                    Console.WriteLine("Dame el nuevo nombre del mercado:");
                    cadenaNombreMercado = Console.ReadLine();
                    Console.WriteLine("Dame la nueva cuota del mercado:");
                    cadenaCuota = Console.ReadLine();
                    cuota = float.Parse(cadenaCuota);
                    // //funcion modificar
                    break;
                case 4:
                    Console.WriteLine("Dame la nueva cuota del mercado:");
                    cadenaCuota = Console.ReadLine();
                    cuota = float.Parse(cadenaCuota);
                    // //funcion modificar
                    break;
                default:

                    break;
            }

        }
        

    }
}
