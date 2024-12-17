using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaReporteAsientosContables
    {
        public static List<EntidadReporteAsientosContables> ListReporteAsientosContables(string periodo_mes, int periodo_anio, string num_docCliente)
        {
            return DatosReporteAsientosContables.ListReporteAsientosContables(periodo_mes, periodo_anio, num_docCliente);
        }
    }
}
