using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadDetalleCita
    {
        public int id_reg_det_cita { get; set; }
        public int id_cita { get; set; }
        public string estado { get; set; }
        public string cod_item_catalogo { get; set; }
        public string descrip_item { get; set; }
        public decimal precio_cita { get; set; }
        public string hora_cita { get; set; }
        public int codigo_especialidad { get; set; }
        public int id_grupo { get; set; }
        public int id_clase { get; set; }
        public bool confirmado { get; set; }
    }
}
