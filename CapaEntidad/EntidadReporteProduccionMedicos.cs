using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public  class EntidadReporteProduccionMedicos
    {
        public string num_doc_cliente { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string nombres { get; set; }
        public string fecha_atencion { get; set; }
        public string hora_atencion { get; set; }
        public string descripcion_servicio { get; set; }
        public string monto_pagar { get; set; }
    }
}
