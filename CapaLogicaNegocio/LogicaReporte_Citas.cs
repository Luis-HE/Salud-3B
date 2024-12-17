using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;
namespace CapaLogicaNegocio
{
   public class LogicaReporte_Citas
    {
        public static List<EntidadReporte_Citas> ListarReporteCitas(string fecha1, string fecha2)
        {
            return DatosReporte_Citas.ListarReporteCitas(fecha1, fecha2);
        }
    }
}
