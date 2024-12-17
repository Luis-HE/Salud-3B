using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
  public  class EntidadLaboratorio
    {
        public int id_reg_laboratorio { get; set; }
        public string num_historia_clinica { get; set; }
        public string num_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public int numero_admision { get; set; }
        public string fecha_muestra { get; set; }
        public string num_informe_lab { get; set; }
        public string diagnostico { get; set; }
        public string dni_empleado { get; set; }
        public int codigo_persona_pago { get; set; }
        public int edad { get; set; }
        public string hora_muestra { get; set; }
    }
}
