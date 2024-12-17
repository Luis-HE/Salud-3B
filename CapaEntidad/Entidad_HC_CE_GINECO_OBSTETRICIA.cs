using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Entidad_HC_CE_GINECO_OBSTETRICIA
    {
        public int id_ginecoobstetricia { get; set; }
        public string numero_historia_clinica { get; set; }
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public int numero_admision { get; set; }
        public string fecha_registro { get; set; }
        public string hora_registro { get; set; }
        public string edad { get; set; }
        public string gesta { get; set; }
        public string paridad1 { get; set; }
        public string paridad2 { get; set; }
        public string paridad3 { get; set; }
        public string paridad4 { get; set; }
        public string fur { get; set; }
        public string fpp { get; set; }
        public string edad_gestacion { get; set; }
        public string antecedentes { get; set; }
        public string motivo_consulta { get; set; }
        public string tiempo_enfermedad { get; set; }
        public string examen_clinico { get; set; }
        public string cod_cie_diez { get; set; }
        public string plan_trabajo { get; set; }
        public string fecha_proxima_cita { get; set; }
        public string observaciones { get; set; }
        public string dni_empleado { get; set; }
        public int codigo_persona_pago { get; set; }
        public string tratamiento { get; set; }
    }
}
