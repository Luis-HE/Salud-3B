using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
  public  class Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE
    {
        public int id_solicitud_examen_detalle { get; set; }
        public int id_patologia_solictud_examen { get; set; }
        public string numero_historia_clinica { get; set; }
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public string codigo_item_catalogo { get; set; }
        public int id_grupo { get; set; }
        public int id_clase { get; set; }
        public string descripcion_item { get; set; }
        public int estado { get; set; }
        public int cantidad_solicita { get; set; }
    }
}
