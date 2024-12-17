using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidad
{
   public class EntidadFormasPago
    {
        public int id_reg_formapago { get; set; }
        public string fecha_pago { get; set; }
        public decimal monto_pago { get; set; }
        public string forma_de_pago { get; set; }
        public string tipo_moneda { get; set; }
        public string numero_documento { get; set; }
        public string serie { get; set; }
        public string tipo_documento { get; set; }
        public int id_unidad_negocio { get; set; }
    }
}
