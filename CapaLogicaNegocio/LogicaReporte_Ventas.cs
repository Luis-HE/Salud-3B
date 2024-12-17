using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
  public  class LogicaReporte_Ventas
    {
        public static List<EntidadReporte_Ventas> ListarReporteVentas(string fecha1, string fecha2)
        {
            return DatosReporte_Ventas.ListarReporteVentas(fecha1, fecha2);
        }
    }
}
