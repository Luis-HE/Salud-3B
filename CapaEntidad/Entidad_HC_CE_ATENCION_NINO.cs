using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public  class Entidad_HC_CE_ATENCION_NINO
    {
        public int id_atencion_nino { get; set; }
        public string numero_historia_clinica { get; set; }
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public int numero_admision { get; set; }
        public string fecha_atencion { get; set; }
        public string hora_atencion { get; set; }
        public string grado_instruccion { get; set; }
        public int id_reg_acompanante { get; set; }
        public int edad { get; set; }
        public string antecedentes_personales { get; set; }
        public string antecedentes_familiares { get; set; }
        public string esquema_vacunacion { get; set; }
        public string vigilancia_crecimiento_desarrollo { get; set; }
        public string anamnesis { get; set; }
        public string problemas_frecuentes_infancia { get; set; }
        public string evaluacion_alimentacion_actual { get; set; }
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
