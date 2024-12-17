using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadTarifario
    {
        public string cod_item_catalogo { get; set; }
        public string descripcion_principal { get; set; }
        public decimal precio_base { get; set; }
        public decimal precio_venta { get; set; }
    }
}
