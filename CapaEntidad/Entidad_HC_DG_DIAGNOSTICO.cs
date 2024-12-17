using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Entidad_HC_DG_DIAGNOSTICO
    {
        public int id_diagnostico { get; set; }
        public string numero_historia_clinica { get; set; }
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public string cod_cie_diez { get; set; }
        public int codigo_especialidad { get; set; }
        public string descripcion_diagnostico { get; set; }
        public string fecha_registro { get; set; }
        public string hora_registro { get; set; }
        public string dni_empleado { get; set; }
        public int codigo_persona_pago { get; set; }
        public string tipo_diagnostico { get; set; }
    }
}
