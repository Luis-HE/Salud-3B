using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Entidad_HC_EM_LIBRO_EMERGENCIA
    {
        public int id_libro_emergencia { get; set; }
        public string numero_historia_clinica { get; set; }
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public string dni_empleado { get; set; }
        public int codigo_persona_pago { get; set; }
        public int numero_admision { get; set; }
        public string fecha_ingreso { get; set; }
        public string hora_ingreso { get; set; }
        public string nombre_paciente { get; set; }
        public int edad { get; set; }
        public string genero { get; set; }
        public string direccion_domiciliaria { get; set; }
        public string diagnostico_ingreso { get; set; }
        public string diagnostico_final { get; set; }
        public string destino_final { get; set; }
        public string hora_termina_atencion { get; set; }
        public string observaciones { get; set; }
        public string nombre_acompanante { get; set; }
    }
}
