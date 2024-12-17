using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadModeloListaHospitalizacion
    {
        public string dni_cliente { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public string tipo_admision { get; set; }
        public string fecha_admision { get; set; }
        public string nombre_familiar { get; set; }
        public string tipo_paciente { get; set; }
    }
}
