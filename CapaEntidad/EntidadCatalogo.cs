using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadCatalogo
    {
        public string cod_item_catalogo { get; set; }
        public int cod_color { get; set; }
        public int cod_categoria { get; set; }
        public int cod_marca { get; set; }
        public int cod_uni_med { get; set; }
        public int cod_modelo { get; set; }
        public string descripcion_principal { get; set; }
        public int peso { get; set; }
        public string tipo_item { get; set; }
        public string estado { get; set; }
        public string cod_segus { get; set; }
        public decimal precio { get; set; }
        public string cuenta_contable { get; set; }
        public string motivo_uso { get; set; }
        public string descripcion_secundaria { get; set; }
        public string ruc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public string codigo_cpt { get; set; }

        public int id_grupo { get; set; }
        public int id_clase { get; set; }

        //variables auxiliar
        public int AuxCountItems { get; set; }
        public int cantidad { get; set; }


    }
}
