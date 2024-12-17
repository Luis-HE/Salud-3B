using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaReporteMovimientoCatalogo
    {
        public static List<EntidadReporteMovimientoCatalogo> ListReporteMovCatalogo(string cod_item_catalogo)
        {
            return DatosReporteMovimientoCatalogo.ListReporteMovCatalogo(cod_item_catalogo);
           
        }
    }
}
