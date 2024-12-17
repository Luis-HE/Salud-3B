using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
  public  class Entidad_HC_CE_ATENCION_ADOLECENTE
    {
        public int id_atencion_adolecente { get; set; }
        public string numero_historia_clinica { get; set; }
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public int numero_admision { get; set; }
        public string fecha_atencion { get; set; }
        public string hora_atencion { get; set; }
        public int edad { get; set; }
        public string grado_instruccion { get; set; }
        public string centro_educativo { get; set; }
        public string ocupacion { get; set; }
        public int id_reg_acompanante { get; set; }
        public string antecedentes_personales { get; set; }
        public string antecedentes_familiares { get; set; }
        public string antecedentes_psicosociales { get; set; }
        public string salud_sexual_reproductiva { get; set; }
        public string salud_bucal { get; set; }
        public string motivo_consulta { get; set; }
        public string tiempo_enfermedad { get; set; }
        public string funciones_biologicas { get; set; }
        public string evaluacion_antropometrica { get; set; }
        public string evaluacion_riesgo_cardiovascular { get; set; }
        public string funciones_vitales { get; set; }
        public string examen_fisico { get; set; }
        public string cod_cie_diez { get; set; }
        public string tratamiento { get; set; }
        public string examenes_auxiliares { get; set; }
        public string referencia { get; set; }
        public string fecha_proxima_cita { get; set; }
        public string dni_empleado { get; set; }
        public int codigo_persona_pago { get; set; }

        
    }
}
