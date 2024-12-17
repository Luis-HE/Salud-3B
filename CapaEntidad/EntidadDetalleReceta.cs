using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadDetalleReceta
    {
        public int id_detalle_receta { get; set; }
        public int id_receta { get; set; }
        public string cod_item_catalogo { get; set; }
        public int id_grupo { get; set; }
        public int id_clase { get; set; }
        public int cantidad_receta { get; set; }
        public string forma_farmaceutica { get; set; }
        public string indicaciones { get; set; }

    }
}
