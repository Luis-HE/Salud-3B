using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
  public  class EntidadReporteVentas
    {
        //public string column1 { get; set; }
        //public string column2 { get; set; }
        //public decimal column3 { get; set; }
        public string codigo_item_catalogo { get; set; }
        public string fecha_emision { get; set; }
        public string descripcion_principal { get; set; }
        public decimal monto_total { get; set; }
        public string numero_documento { get; set; }
        public string tipo_documento { get; set; }
    }
}
