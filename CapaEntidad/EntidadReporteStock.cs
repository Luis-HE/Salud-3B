using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadReporteStock
    {
        public string codigo_item_catalogo { get; set; }
        public string descripcion_principal { get; set; }
        public int stock_minimo { get; set; }
        public int cantidad { get; set; }
        public string Unidad_medida { get; set; }
        public decimal precio_actual { get; set; }
        public decimal costo_inventario { get; set; }
        public string descripcion_secundaria { get; set; }

    }
}
