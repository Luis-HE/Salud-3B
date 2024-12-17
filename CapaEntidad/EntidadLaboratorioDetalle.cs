using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public  class EntidadLaboratorioDetalle
    {
        public int id_reg_det_lab { get; set; }
        public int id_reg_laboratorio { get; set; }
        public string numero_historia_clinica { get; set; }
        public string num_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public string descripcion { get; set; }
        public string valor_resultado { get; set; }
    }
}
