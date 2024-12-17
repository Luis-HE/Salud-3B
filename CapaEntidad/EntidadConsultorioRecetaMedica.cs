using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
 public    class EntidadConsultorioRecetaMedica
    {
        public int id_receta { get; set; }
        public string fecha_hasta_vigencia { get; set; }
        public string dni_empleado { get; set; }
        public int cod_persona_pago { get; set; }
        public int num_admision { get; set; }
        public string num_doc_cliente { get; set; }
        public int cod_persona { get; set; }
        public bool alergico { get; set; }
        public string indicaciones { get; set; }
        public string fecha_receta { get; set; }

    }
}
