using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadLiquidacionAtencion
    {
        public string numero_documento { get; set; }
        public string tipo_documento { get; set; }
        public string fecha_emision { get; set; }
        public string codigo_item_catalogo { get; set; }
        public string descrip_item { get; set; }
        public decimal valor_venta { get; set; }
        public int cantidad { get; set; }
        public string tipo_item_catlogo { get; set; }
        public string estado_pago { get; set; }
    }
}
