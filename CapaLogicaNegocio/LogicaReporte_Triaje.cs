using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaReporte_Triaje
    {
        public static List<EntidadReporte_Triaje> ListarRepporteTriaje(string fecha1, string fecha2)
        {
          return   DatosReporte_Triaje.ListarRepporteTriaje(fecha1, fecha2);
        }
    }
}
