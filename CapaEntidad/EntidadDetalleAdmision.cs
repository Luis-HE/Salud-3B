using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadDetalleAdmision
    {
        public int id_reg_det_admision { get; set; }
        public int num_admision { get; set; }
        public string codigo_item { get; set; }
        public string estado { get; set; }
        public string descrip_item { get; set; }
        public decimal precio_atencion { get; set; }
        public string hora { get; set; }
        public int codigo_especialidad { get; set; }
        public int id_grupo { get; set; }
        public int id_clase { get; set; }
    }
}
