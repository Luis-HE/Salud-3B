using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadEmergencia
    {
        public int id_emergencia { get; set; }
        public string num_hist_clinica { get; set; }
        public string num_doc_cliente { get; set; }
        public int cod_persona { get; set; }
        public int numero_admision { get; set; }
        public string medico_tratante { get; set; }
        public string condicion_paciente { get; set; }
        public string prioridad { get; set; }
        public string forma_inicio { get; set; }
        public string tiempo_enfermedad { get; set; }
        public string sintomas_principales { get; set; }
        public string relato_cronologico { get; set; }
        public string antecedentes { get; set; }
        public string apreciacion_general { get; set; }
        public string dni_empleado { get; set; }
        public string cod_persona_pago { get; set; }
        public string fecha_atencion { get; set; }
        public string fecha_consulta_externa { get; set; }
    }
}
