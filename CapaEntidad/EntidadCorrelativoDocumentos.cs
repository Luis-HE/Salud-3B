using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadCorrelativoDocumentos
    {
        public string tipo_documento { get; set; }
        public string serie { get; set; }
        public int correlativo { get; set; }
        public int id_unidad_negocio { get; set; }
        public string descripcion { get; set; }
    }
}
