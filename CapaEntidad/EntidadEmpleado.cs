using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadEmpleado
    {
        public string dni_empleado { get; set; }
        public int cod_personaPago { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public int cod_area { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string num_cuenta { get; set; }
        public string nombre_banco { get; set; }
        public decimal porcentaje_comision { get; set; }
        public string num_ruc { get; set; }
        public string tipo_contrato { get; set; }
    }
}
