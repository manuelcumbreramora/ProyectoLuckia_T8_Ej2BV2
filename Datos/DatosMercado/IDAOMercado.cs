using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DatosMercado
{
    interface IDAOMercado
    {
        DTOMercado CrearMercadoDAO(DTOMercado mercadoDTO);

        DTOMercado RecuperarMercadoPorIdMercadoDAO(int id);

        DTOMercado ModificarNombreMercado(int idEvento, string nombreMercado);

        DTOMercado ModificarCuotaMercado(int idEvento, float cuota);
    }
}
