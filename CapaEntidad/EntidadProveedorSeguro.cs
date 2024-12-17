using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadProveedorSeguro
    {
        public int id_cia_seguro { get; set; }
        public string ruc_proveedor { get; set; }
        public int codigo_persona_pago { get; set; }
        public string nombre_seguro { get; set; }
    }
}
