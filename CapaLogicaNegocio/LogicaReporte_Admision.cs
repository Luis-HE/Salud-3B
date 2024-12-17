using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaReporte_Admision
    {
        public static List<EntidadReporte_Admision> ListarReporteAdmision(string fecha1, string fecha2)
        {
            return DatosReporte_Admision.ListarReporteAdmision(fecha1, fecha2);
        }
    }
}
