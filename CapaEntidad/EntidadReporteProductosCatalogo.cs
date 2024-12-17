using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadReporteProductosCatalogo
    {
        public string cod_item { get; set; }
        public string descripcion_principal { get; set; }
        public string descripcion_secundaria { get; set; }
        public string cantidad { get; set; }
        public string numero_lote { get; set; }
        public string fecha_mov { get; set; }
        public string fecha_vence { get; set; }
        public string precio_entra { get; set; }
        public string tipo_doc { get; set; }
        public string numero_doc { get; set; }
        public string razon_social { get; set; }
    }
}
