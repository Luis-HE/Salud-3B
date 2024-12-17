using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadDetalleConvenio
    {
        public int id_reg_detConvenio { get; set; }
        public int id_regConvenio { get; set; }
        public int id_ciaSeg { get; set; }
        //public string ruc_proveedor { get; set; }
        //public int cod_persona_pago { get; set; }
        public string cod_item_catalogo { get; set; }
        public decimal porcentaje_cubre { get; set; }
        public decimal precio_venta { get; set; }
        public decimal factor_calculo { get; set; }

        public int id_grupo { get; set; }
        public int id_clase { get; set; }

    }
}
