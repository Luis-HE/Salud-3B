using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaReporteProductosCatalogo
    {
        public static List<EntidadReporteProductosCatalogo> ListReporteProductosCatalogo()
        {
           return DatosReporteProductosCatalogo.ListReporteProductosCatalogo();
        }
    }
}
