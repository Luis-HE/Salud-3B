using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadConvenio
    {
        public int id_reg_convenio { get; set; }
        public int id_cia_seguro { get; set; }        
        public string fecha_convenio { get; set; }
        public string duracion { get; set; }
        public string firmante { get; set; }
        public string observacion { get; set; }
    }
}
