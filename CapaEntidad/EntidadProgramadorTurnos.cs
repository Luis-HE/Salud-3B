using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadProgramadorTurnos
    {
        public int id_registro { get; set; }
        public string hora { get; set; }
        public int id_turno { get; set; }
        public string dni_empleado { get; set; }
        public int cod_persona { get; set; }
        public string dni_paciente { get; set; }
        public string id_item { get; set; }
        public int cod_especialidad { get; set; }
        public string estado { get; set; }
        public string fecha { get; set; }
    }
}
