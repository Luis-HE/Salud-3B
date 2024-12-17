using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Entidad_TBL_HC_FESP_NOTA_ENFERMERIA
    {
        public int id_nota_enfermeria { get; set; }
        public string fecha_registro { get; set; }
        public string hora_registro { get; set; }
        public int id_registro_hospitalizacion { get; set; }
        public string numero_historia_clinica { get; set; }
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public int id_cama { get; set; }
        public int id_piso { get; set; }
        public string evolucion_enfermeria { get; set; }
        public string dni_empleado { get; set; }
        public int codigo_persona_pago { get; set; }
    }
}
