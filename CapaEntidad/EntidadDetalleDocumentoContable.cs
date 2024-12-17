using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadDetalleDocumentoContable
    {
        public int id_reg_det_doc { get; set; }
        public string numero_documento { get; set; }
        public string serie { get; set; }
        public int id_unidad_negocio { get; set; }
        public string tipo_documento { get; set; }
        public string cod_item_catalogo { get; set; }
        public string descrip_detalle { get; set; }
        public decimal valor_venta { get; set; }
        public decimal descuento_unit { get; set; }
        public string estado { get; set; }
        public int cantidad { get; set; }
        public int id_grupo { get; set; }
        public int id_clase { get; set; }
        public string tipo_afectacion_igv { get; set; }
        public string codigo_producto_sunat { get; set; }
        public int porcentaje_descuento { get; set; }
        public decimal valor_unitario { get; set; }
        public decimal valor_igv { get; set; }
        public decimal valor_isc { get; set; }
        public int porcentaje_isc { get; set; }
        public decimal otro_cargo { get; set; }
        public int porcentaje_otro_cargo { get; set; }
        public decimal otro_tributo { get; set; }
        public int porcentaje_otro_tributo { get; set; }
        public decimal importe_total { get; set; }



    }
}
