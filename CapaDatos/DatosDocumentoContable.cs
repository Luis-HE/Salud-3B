using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using CapaEntidad;

namespace CapaDatos
{
   public class DatosDocumentoContable
    {
        public static void CreateDocumentoContableAdmin(EntidadDocumentoContable entDocContable)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                 string query = "INSERT INTO TBL_DOCUMENTO_CONTABLE(numero_documento,serie,codigo_persona,tipo_operacion,fecha_emision,subtotal,igv,total,tipo_documento,observacion,descuento_total,numero_documento_cliente,fecha_cobranza,nombre_usuario,nombre_cliente,direccion_cliente,numero_admision,id_unidad_negocio,numero_doc_referencia,tipo_moneda,total_base_imponible,total_isc,total_otro_cargo,total_otro_tributo,tiene_doc_referencia,tipo_doc_referencia,serie_doc_referencia,condicion_pago,numero_orden_compra,numero_guia_remision,mensaje_detraccion,transferencia_gratuita, documento_relacionado,descuento_global,otro_cargo_global,anticipo ) VALUES('" + entDocContable.numerodocumento+"','"+entDocContable.serie+"','"+entDocContable.cod_persona+"','"+entDocContable.tipo_operacion+"','"+entDocContable.fecha_emision+"','"+entDocContable.sub_total+"','"+entDocContable.igv+"','"+entDocContable.total+"','"+entDocContable.tipo_documento+"','"+entDocContable.observacion+"','"+entDocContable.descuento_total+"','"+entDocContable.numero_doc_cliente+"','"+entDocContable.fecha_cobranza+"','"+entDocContable.nombre_usuario+"','"+entDocContable.nombre_cliente+"','"+entDocContable.direccion_cliente+"','"+entDocContable.numero_admision+"','"+entDocContable.id_unidad_negocio+ "', '" + entDocContable.numero_doc_referencia + "','" + entDocContable.tipo_moneda + "' ,'" + entDocContable.total_base_imponible + "' ,'" + entDocContable.total_isc + "' ,'" + entDocContable.total_otro_cargo + "' ,'" + entDocContable.total_otro_tributo + "' ,'" + entDocContable.tiene_doc_referencia + "' ,'" + entDocContable.tipo_doc_referencia + "' ,'" + entDocContable.serie_doc_referencia + "' ,'" + entDocContable.condicion_pago + "' ,'" + entDocContable.numero_orden_compra + "' ,'" + entDocContable.numero_guia_remision + "' ,'" + entDocContable.mensaje_detraccion + "' ,'" + entDocContable.transferencia_gratuita + "' ,'" + entDocContable.documento_relacionado + "' ,'" + entDocContable.descuento_global + "' ,'" + entDocContable.otro_cargo_global + "' ,'" + entDocContable.anticipo + "' )";
                 con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public static void CreateDocumentoContable(EntidadDocumentoContable entDocContable)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                //venta directa de farmacia, SIN NUMERO DE ADMISION DEL PACIENTE
                 string  query = "INSERT INTO TBL_DOCUMENTO_CONTABLE(numero_documento,serie,codigo_persona,tipo_operacion,fecha_emision,subtotal,igv,total,tipo_documento,observacion,descuento_total,numero_documento_cliente,fecha_cobranza,nombre_usuario,nombre_cliente,direccion_cliente,id_unidad_negocio ,numero_doc_referencia,tipo_moneda,total_base_imponible,total_isc,total_otro_cargo,total_otro_tributo,tiene_doc_referencia,tipo_doc_referencia,serie_doc_referencia,condicion_pago,numero_orden_compra,numero_guia_remision,mensaje_detraccion,transferencia_gratuita, documento_relacionado,descuento_global,otro_cargo_global,anticipo  ) VALUES('" + entDocContable.numerodocumento + "','" + entDocContable.serie + "','" + entDocContable.cod_persona + "','" + entDocContable.tipo_operacion + "','" + entDocContable.fecha_emision + "','" + entDocContable.sub_total + "','" + entDocContable.igv + "','" + entDocContable.total + "','" + entDocContable.tipo_documento + "','" + entDocContable.observacion + "','" + entDocContable.descuento_total + "','" + entDocContable.numero_doc_cliente + "','" + entDocContable.fecha_cobranza + "','" + entDocContable.nombre_usuario + "','" + entDocContable.nombre_cliente + "','" + entDocContable.direccion_cliente + "','" + entDocContable.id_unidad_negocio + "'  , '" + entDocContable.numero_doc_referencia + "','" + entDocContable.tipo_moneda + "' ,'" + entDocContable.total_base_imponible + "' ,'" + entDocContable.total_isc + "' ,'" + entDocContable.total_otro_cargo + "' ,'" + entDocContable.total_otro_tributo + "' ,'" + entDocContable.tiene_doc_referencia + "' ,'" + entDocContable.tipo_doc_referencia + "' ,'" + entDocContable.serie_doc_referencia + "' ,'" + entDocContable.condicion_pago + "' ,'" + entDocContable.numero_orden_compra + "' ,'" + entDocContable.numero_guia_remision + "' ,'" + entDocContable.mensaje_detraccion + "' ,'" + entDocContable.transferencia_gratuita + "' ,'" + entDocContable.documento_relacionado + "' ,'" + entDocContable.descuento_global + "' ,'" + entDocContable.otro_cargo_global + "' ,'" + entDocContable.anticipo + "' )";
               
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                { 
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public static List<EntidadDocumentoContable> ReadDocumentoContable()
        {
            List<EntidadDocumentoContable> lst = new List<EntidadDocumentoContable>();
            return lst;
        }
        public static void UpdateDocumentoContable(EntidadDocumentoContable entDocContable)
        {

        }
        public static void DeleteDocumentoContable(EntidadDocumentoContable entDocContable)
        {

        }
    }
}
