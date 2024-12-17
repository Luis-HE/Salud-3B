using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
  public  class LogicaReporteProduccionMedicos
    {
        public static List<EntidadReporteProduccionMedicos> ListarReportexDNI(string dni_empleado)
        {
            return DatosReporteProduccionMedicos.ListarReportexDNI(dni_empleado);
        }
    }
}
