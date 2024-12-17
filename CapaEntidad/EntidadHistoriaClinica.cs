using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntidadHistoriaClinica
    {
        public string num_hist_clinica { get; set; } 
        public string fecha_creacion { get; set; }
        public string num_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public string persona_crea { get; set; }
    }
}
