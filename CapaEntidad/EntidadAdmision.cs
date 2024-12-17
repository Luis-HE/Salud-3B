using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadAdmision
    {
        public int numero_admision { get; set; }
        public string fecha_admision { get; set; }
        public string nombre_usuario { get; set; }
        public string observacion { get; set; }
        public decimal monto_adelanto { get; set; }
        public decimal cobertura { get; set; }
        public string tipo_admision { get; set; }
        public string tipo_paciente { get; set; }
        public int id_cia_seguro { get; set; }
        public string numero_doc_cliente { get; set; }
        public int id_cita { get; set; }
        public bool paciente_vip { get; set; }
        public int codigo_persona { get; set; }
        public int id_reg_acompanante { get; set; }
        public string cod_carta_garantia { get; set; }
        public string nomb_garante { get; set; }
 
    }
}
