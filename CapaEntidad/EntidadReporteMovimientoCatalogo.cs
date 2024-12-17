using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadReporteMovimientoCatalogo
    {
        public string fecha_mov { get; set; }
        public string descripcion { get; set; }
        public int cant_entra { get; set; }
        public decimal precio_entra { get; set; }
        public decimal total_entra { get; set; }
        public int cant_sale { get; set; }
        public decimal precio_sale { get; set; }
        public decimal total_sale { get; set; }
        public string cant_existe { get; set; }
        public string precio_existe { get; set; }
        public string total_existe { get; set; }
    }
}
