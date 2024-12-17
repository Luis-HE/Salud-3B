using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
  public  class EntidadCita
    {
        public int id_cita { get; set; }
        public string fecha_registro { get; set; }
        public string num_doc_cliente { get; set; }
        public int id_cia_seguro { get; set; }
        public string tipo_paciente { get; set; }    
        public int cod_persona { get; set; }
        public string fecha_cita { get; set; }
        public string observacion { get; set; }
        public string nombre_usuario { get; set; }

    }
}
