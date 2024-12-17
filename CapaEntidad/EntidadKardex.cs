using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadKardex
    {
        public string codigo_item_catalogo { get; set; }
        public int codigo_almacen { get; set; }
        public int id_grupo { get; set; }
        public int id_clase { get; set; }
        public int id_unidad_negocio { get; set; }
        public int cantidad_para_almacenar { get; set; }
        public int stock_minimo { get; set; }
        public decimal precio_global_almacenamiento { get; set; }
        public int cantidad_para_despachar { get; set; }
        public decimal precio_unitario_despacho { get; set; }
        public int factor_conversion_equivalencia { get; set; }
        public string fecha_vencimiento { get; set; }
    }
}
