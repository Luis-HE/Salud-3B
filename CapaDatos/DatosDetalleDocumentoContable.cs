using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using CapaEntidad;

namespace CapaDatos
{
   public class DatosDetalleDocumentoContable
    {
        public static void InsertDetalleDocumentoContable(EntidadDetalleDocumentoContable entDetDoc)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_DOCUMENTO_CONTABLE_DETALLE(id_detalle_doc,numero_documento,serie,tipo_documento,codigo_item_catalogo,descripcion_detalle,valor_venta,descuento_unitario,estado,cantidad,id_grupo,id_clase,id_unidad_negocio, tipo_afectacion_igv,codigo_producto_sunat,porcentaje_descuento,valor_unitario,valor_igv,valor_isc,porcentaje_isc,otro_cargo,porcentaje_otro_cargo,otro_tributo,porcentaje_otro_tributo, importe_total ) VALUES((SELECT ISNULL(MAX(id_detalle_doc),0)+1 FROM TBL_DOCUMENTO_CONTABLE_DETALLE),'" + entDetDoc.numero_documento+"','"+entDetDoc.serie+"','"+entDetDoc.tipo_documento+"','"+entDetDoc.cod_item_catalogo+"','"+entDetDoc.descrip_detalle+"','"+entDetDoc.valor_venta+"','"+entDetDoc.descuento_unit+"','"+entDetDoc.estado+"','"+entDetDoc.cantidad+ "','" + entDetDoc.id_grupo + "' ,'" + entDetDoc.id_clase + "' ,'" + entDetDoc.id_unidad_negocio + "','" + entDetDoc.tipo_afectacion_igv + "','" + entDetDoc.codigo_producto_sunat + "','" + entDetDoc.porcentaje_descuento + "','" + entDetDoc.valor_unitario + "','" + entDetDoc.valor_igv + "','" + entDetDoc.valor_isc + "','" + entDetDoc.porcentaje_isc + "','" + entDetDoc.otro_cargo + "','" + entDetDoc.porcentaje_otro_cargo + "','" + entDetDoc.otro_tributo + "','" + entDetDoc.porcentaje_otro_tributo + "','" + entDetDoc.importe_total + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
