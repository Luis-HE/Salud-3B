using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Entidad_HC_CE_CIRUGIA_AMBULATORIA
    {
        public int id_cirugia_ambulatoria { get; set; }
        public string numero_historia_clinica { get; set; }
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public int numero_admision { get; set; }
        public string fecha_atencion { get; set; }
        public string hora_atencion { get; set; }
        public string anamnesis { get; set; }
        public string antecedentes { get; set; }
        public string examen_fisico { get; set; }
        public string desarrollo_psicomotor { get; set; }
        public string examenes { get; set; }
        public string cod_cie_diez { get; set; }
        public string tratamiento { get; set; }
        public string operacion { get; set; }
        public string indicaciones { get; set; }
        public string evolucion_postoperatoria { get; set; }
        public string indicaciones_alta { get; set; }
        public string dni_empleado { get; set; }
        public int codigo_persona_pago { get; set; }

    }
}
