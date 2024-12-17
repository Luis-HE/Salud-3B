using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadTurno
    {
        public int id_turno { get; set; }
        public string hora { get; set; }
        public string dni_empleado { get; set; }
        public int cod_persona_pago { get; set; }
        public string dni_paciente { get; set; }
        public string cod_item_catalogo { get; set; }
        public int cod_especialidad { get; set; }
        public string estado { get; set; }
        public string fecha { get; set; }
        public string descripcion_item { get; set; }
        public decimal precio_item { get; set; }

    }
}
