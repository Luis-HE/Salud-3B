using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadModeloBuscaPacCitado
    {
        public int numero_cita { get; set; }
        public string dni_cliente { get; set; }
        public string nombre_cliente { get; set; }
        public string tipo_paciente { get; set; }
        public int cod_cia_seguro { get; set; }
        public string plan_asegurador { get; set; }
        public string cod_item_catalogo { get; set; }
        public string descripcion_item { get; set; }
        public string observacion { get; set; }
        public decimal precio_citado { get; set; }
        public int id_grupo { get; set; }
        public int id_clase { get; set; }
    }
}
