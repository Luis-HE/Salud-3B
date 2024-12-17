using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadModeloBuscaPacAtendido
    {
        public int numero_admision { get; set; }
        public string fecha_atencion { get; set; }
        public string paciente { get; set; }
        public string direccion { get; set; }
        public string medico { get; set; }
        public string anotaciones { get; set; }
        public string nombreCie { get; set; }
        public string num_doc_cliente { get; set; }
        public string fecha_nace { get; set; }
        //=============para los pacinetes ATENDIDOS y con RECETA MEDICA
        public string codigo_item_catalogo { get; set; }
        public string descripcion_item { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal precio_venta { get; set; }
        public int id_grupo { get; set; }
        public int id_clase { get; set; }
    }
}
