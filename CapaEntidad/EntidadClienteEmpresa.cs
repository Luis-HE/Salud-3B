using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadClienteEmpresa
    {
        public string ruc_cliente { get; set; }
        public int cod_persona { get; set; }
        public string razon_social { get; set; }
        public string razon_comercial { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string contacto { get; set; }
        public string dni_vendedor { get; set; }
    }
}
