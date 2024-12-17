using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public  class Entidad_HC_EM_ATENCION_EMERGENCIA
    {
        public int id_atencion_emergencia { get; set; }
        public string numero_historia_clinica { get; set; }
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public string dni_empleado { get; set; }
        public int codigo_persona_pago { get; set; }
        public int numero_admision { get; set; }
        public string fecha_atencion { get; set; }
        public string hora_atencion { get; set; }
        public string filiacion { get; set; }
        public string anamnesis_enfermedad_actual { get; set; }
        public string antecedentes { get; set; }
        public string examen_fisico { get; set; }
        public int id_consentimiento_informado { get; set; }
        public int id_autoriza_procedimiento_quirurgico { get; set; }
        public string examenes_auxiliares { get; set; }
        public string diagnostico_presuntivo { get; set; }
        public string plan_trabajo { get; set; }
        public string terapeutica_seguimiento { get; set; }
        public string epicrisis_resumen_historia { get; set; }
        public int id_materno_perinatal { get; set; }
        public int id_partograma { get; set; }
        public string prioridad { get; set; }
    }
}
