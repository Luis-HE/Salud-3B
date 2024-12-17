using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN
    {
        public int id_patologia_solicitud_examen { get; set; }
        public string numero_historia_clinica { get; set; }
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public int numero_admision { get; set; }
        public string fecha_registro { get; set; }
        public string dni_empleado { get; set; }
        public int codigo_persona_pago { get; set; }
        public string motivo_solicitud { get; set; }
        public string edad_paciente { get; set; }
        public string indicaciones_medicas { get; set; }
        public string diagnostico_presuntivo { get; set; }
    }
}
