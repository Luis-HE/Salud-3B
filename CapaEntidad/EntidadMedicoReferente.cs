using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadMedicoReferente
    {
        public string cmp { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string nombres { get; set; }
        public string telefono_fijo { get; set; }
        public string telefono_movil { get; set; }
        public string email { get; set; }
        public int codigo_especialidad { get; set; }
    }
}
