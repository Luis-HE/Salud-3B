using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadProveedor
    {
        public string ruc_proveedor { get; set; }
        public string razon_social { get; set; }
        public string razon_comercial { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string representante { get; set; }
        public int cod_persona_pago { get; set; }
        public string numero_cuenta { get; set; }
        public string nombre_banco { get; set; }
    }
}
