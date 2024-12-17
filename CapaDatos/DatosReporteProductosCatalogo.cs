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
   public class DatosReporteProductosCatalogo
    {
        public static List<EntidadReporteProductosCatalogo> ListReporteProductosCatalogo()
        {
            List<EntidadReporteProductosCatalogo> lst = new List<EntidadReporteProductosCatalogo>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "SELECT TBL_CATALOGO.codigo_item_catalogo AS CodItem,descripcion_principal,descripcion_secundaria,cantidad,numero_lote,fecha_mov,fecha_vencimiento,precio_entrada,tipo_documento,numero_documento,razon_social FROM TBL_PROVEEDOR INNER JOIN(TBL_CATALOGO inner join TBL_MOV_CATALOGO on TBL_CATALOGO.codigo_item_catalogo=TBL_MOV_CATALOGO.codigo_item_catalogo) ON TBL_PROVEEDOR.ruc_proveedor= TBL_MOV_CATALOGO.ruc_proveedor WHERE tipo_movimiento = 'Entrada' order by descripcion_principal";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadReporteProductosCatalogo entRepPrdCatal = new EntidadReporteProductosCatalogo()
                            {
                                cod_item = dr["CodItem"].ToString(),
                                descripcion_principal = dr["descripcion_principal"].ToString(),
                                descripcion_secundaria = dr["descripcion_secundaria"].ToString(),
                                cantidad = dr["cantidad"].ToString(),
                                numero_lote = dr["numero_lote"].ToString(),
                                fecha_mov = dr["fecha_mov"].ToString(),
                                fecha_vence = dr["fecha_vencimiento"].ToString(),
                                precio_entra = dr["precio_entrada"].ToString(),
                                tipo_doc = dr["tipo_documento"].ToString(),
                                numero_doc = dr["numero_documento"].ToString(),
                                razon_social = dr["razon_social"].ToString()
   
                            };
                            lst.Add(entRepPrdCatal);

                        }
                    }
                }

            }
            return lst;
        }
    }
}
