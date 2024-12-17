using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadCatalogoCiediez
    {
        public string codigo_ciediez { get; set; }
        public string capitulo { get; set; }
        public string grupo { get; set; }
        public string categoria { get; set; }
        public string subcategoria { get; set; }
        public string nombre { get; set; }
        public string simbolo { get; set; }
        public string genero_aplica { get; set; }
        public int limite_inferior { get; set; }
        public int limite_superior { get; set; }
        public string afecccion_principal { get; set; }
        public string observacion { get; set; }
    }
}
