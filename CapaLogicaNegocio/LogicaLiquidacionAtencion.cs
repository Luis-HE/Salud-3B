using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaLiquidacionAtencion
    {
        public static List<EntidadLiquidacionAtencion> ListLiquidacionAtencion(string dni_cliente)
        {
            return DatosLiquidacionAtencion.ListLiquidacionAtencion(dni_cliente);
        }
    }
}
