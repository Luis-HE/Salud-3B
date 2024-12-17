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
   public class DatosMovimientoCatalogo
    {
        public static List<EntidadMovimientoCatalogo> ListMovimientosProductos()
        {
            List<EntidadMovimientoCatalogo> lst = new List<EntidadMovimientoCatalogo>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadMovimientoCatalogo entMovCatal = new EntidadMovimientoCatalogo()
                            {

                            };
                            lst.Add(entMovCatal);
                        }
                    }
                }

            }

            return lst;
        }
        public static void InsertMovimientoCatalogo(EntidadMovimientoCatalogo entMovCat)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_MOVIMIENTO_CATALOGO(id_registro_mov,fecha_mov,cantidad,codigo_item_catalogo,nombre_usuario,precio_entrada,precio_venta,codigo_almacen,numero_documento,tipo_documento,tipo_movimiento,motivo,ruc_proveedor,codigo_persona_pago,numero_lote,fecha_vencimiento,id_grupo,id_clase,id_unidad_negocio) VALUES((SELECT ISNULL(MAX(id_registro_mov),0)+1 FROM TBL_MOVIMIENTO_CATALOGO),'" + entMovCat.fecha_movimiento+"','"+entMovCat.cantidad+"','"+entMovCat.cod_item_catalogo+"','"+entMovCat.codigo_usuario+"','"+entMovCat.precio_entrada+"','"+entMovCat.precio_venta+"','"+entMovCat.codigo_almacen+"','"+entMovCat.numero_documento+"','"+entMovCat.tipo_documento+"','"+entMovCat.tipo_movimiento+"','"+entMovCat.motivo+"','"+entMovCat.ruc_proveedor+"','"+entMovCat.cod_persona_pago+"','"+entMovCat.numero_lote+"','"+entMovCat.fecha_vence+"','"+entMovCat.id_grupo+"','"+entMovCat.id_clase+"','"+entMovCat.id_unidad_negocio+"' ) ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
 
    }
}
