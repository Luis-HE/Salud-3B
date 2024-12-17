using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaReporteCierreCaja
    {
        public static List<EntidadReporteCierreCaja> ListReporteCierreCaja(string fecha_inicio, string fecha_fin)
        {
            return DatosReporteCierreCaja.ListReporteCierreCaja(fecha_inicio, fecha_fin);
        }
    }
}
