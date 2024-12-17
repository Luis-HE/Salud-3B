using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadReporteCierreCaja
    {
        public string Num_doc_cliente { get; set; }
        public string numero_documento { get; set; }
        public string Nombre_cliente { get; set; }
        public decimal monto_pago { get; set; }
        public string fecha_pago { get; set; }
    }
}
