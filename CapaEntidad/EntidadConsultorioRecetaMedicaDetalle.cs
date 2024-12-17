using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public  class EntidadConsultorioRecetaMedicaDetalle
    {
        public int id_det_receta { get; set; }
        public int id_receta { get; set; }
        public string codigo_item_catalogo { get; set; }
        public int id_grupo { get; set; }
        public int id_clase { get; set; }
        public int cantidad_receta { get; set; }
        public string forma_farmaceutica { get; set; }
        public int estado { get; set; }
        public string descripcion_item { get; set; }
        public string concentracion { get; set; }
        public string via_administracion { get; set; }
        public string frecuencia { get; set; }
        public string tratamiento { get; set; }
    }
}
