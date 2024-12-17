using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadReporteLibroMayor
    {
        public int id_regLibro { get; set; }
        public string periodo_mes { get; set; }
        public int periodo_anio { get; set; }
        public string nombre_cliente { get; set; }
        public string numAsiento_contable { get; set; }
        public string fecha { get; set; }
        public string definicion { get; set; }
        public string cuenta_contable { get; set; }
        public string descripcion_cuenta { get; set; }
        public string debe { get; set; }
        public string haber { get; set; }
    }
}
