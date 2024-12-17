using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaReporteVentas
    {
        public static List<EntidadReporteVentas> ListarVentas()
        {
            return DatosReporteVentas.ListarVentas();
        }
        public static List<EntidadReporteVentas> ListReporteVentasFarmacia(string fechaIni, string fechaFin)
        {
            return DatosReporteVentas.ListReporteVentasFarmacia(fechaIni, fechaFin);
        }
    }
}
