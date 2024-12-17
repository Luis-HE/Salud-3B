using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadAsientoContable
    {
        public int id_regAsiento { get; set; }
        public string fecha_operacion { get; set; }
        public string descrip_operacion { get; set; }
        public string num_doc_contable { get; set; }
        public string debe { get; set; }
        public string haber { get; set; }
        public decimal redondeo { get; set; }
        public int id_regPlancontable { get; set; }
        public int periodo_anio { get; set; }
        public string periodo_mes { get; set; }
        public string num_doc_cliente { get; set; }
        public string nombre_cliente { get; set; }
        public string tipo_doc_contable { get; set; }
    }
}
