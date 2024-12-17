using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadDocumentoContable
    {
        public string numerodocumento { get; set; }
        public string serie { get; set; }
        public string tipo_documento { get; set; }
        public int id_unidad_negocio { get; set; }
        public int cod_persona { get; set; }
        public string tipo_operacion { get; set; }
        public string fecha_emision { get; set; }
        public decimal sub_total { get; set; }
        public decimal igv { get; set; }
        public decimal total { get; set; }
        public string observacion { get; set; }
        public decimal descuento_total { get; set; }
        public string numero_doc_cliente { get; set; }
        public string fecha_cobranza { get; set; }
        public string nombre_usuario { get; set; }
        public string nombre_cliente { get; set; }
        public string direccion_cliente { get; set; }
        public int numero_admision { get; set; }
        public string numero_doc_referencia { get; set; }
        public string tipo_moneda { get; set; }
        public decimal total_base_imponible { get; set; }
        public decimal total_isc { get; set; }
        public decimal total_otro_cargo { get; set; }
        public decimal total_otro_tributo { get; set; }
        public int tiene_doc_referencia { get; set; }
        public string tipo_doc_referencia { get; set; }
        public string serie_doc_referencia { get; set; }
        public string condicion_pago { get; set; }
        public string numero_orden_compra { get; set; }
        public string numero_guia_remision { get; set; }
        public int mensaje_detraccion { get; set; }
        public int transferencia_gratuita { get; set; }
        public int documento_relacionado { get; set; }
        public int descuento_global { get; set; }
        public int otro_cargo_global { get; set; }
        public int anticipo { get; set; }
         
    }
}
