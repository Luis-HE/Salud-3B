using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Entidad_HC_CE_ATENCION_ADULTO
    {
        public int id_atencion_adulto { get; set; }
        public string numero_historia_clinica { get; set; }
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public int numero_admision { get; set; }
        public string fecha_atencion { get; set; }
        public string hora_atencion { get; set; }
        public string grado_instruccion { get; set; }
        public string centro_educativo { get; set; }
        public string ocupacion { get; set; }
        public string antecedentes_personales { get; set; }
        public string antecedentes_familiares { get; set; }
        public string alergia_medicamentos { get; set; }
        public string sexualidad { get; set; }
        public string salud_bucal { get; set; }
        public string motivo_consulta { get; set; }
        public string tiempo_enfermedad { get; set; }
        public string funciones_biologicas { get; set; }
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
