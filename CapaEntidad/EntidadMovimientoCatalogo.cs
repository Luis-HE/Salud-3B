using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadMovimientoCatalogo
    {
        public int id_reg_mov { get; set; }
        public string cod_item_catalogo { get; set; }
        public string fecha_movimiento { get; set; }
        public int cantidad { get; set; }
        public string codigo_usuario { get; set; }
        public decimal precio_entrada { get; set; }
        public decimal precio_venta { get; set; }
        public int codigo_almacen { get; set; }
        public string numero_documento { get; set; }
        public string tipo_documento { get; set; }
        public string tipo_movimiento { get; set; }
        public string motivo { get; set; }
        public string ruc_proveedor { get; set; }
        public int cod_persona_pago { get; set; }
        public string numero_lote { get; set; }
        public string fecha_vence { get; set; }
        public int id_grupo { get; set; }
        public int id_clase { get; set; }
        public int id_unidad_negocio { get; set; }

    }
}
