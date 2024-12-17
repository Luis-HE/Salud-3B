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
    public class DatosKardex
    {
        public static List<EntidadKardex> ListKardex()
        {
            List<EntidadKardex> lst = new List<EntidadKardex>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select  codigo_item_catalogo,codigo_almacen,id_grupo,id_clase,id_unidad_negocio,cantidad_para_almacenar,stock_minimo,precio_global_almacenamiento,cantidad_para_despachar,precio_unitario_despacho,factor_conversion_equivalencia,fecha_vencimiento from TBL_KARDEX";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            EntidadKardex entKar = new EntidadKardex()
                            {
                                codigo_item_catalogo =dr["codigo_item_catalogo"].ToString(),
                                cantidad_para_almacenar = Convert.ToInt32(dr["cantidad_para_almacenar"]),
                                stock_minimo = Convert.ToInt32(dr["stock_minimo"]),
                                precio_global_almacenamiento = Convert.ToDecimal(dr["precio_global_almacenamiento"]),
                                codigo_almacen = Convert.ToInt32(dr["codigo_almacen"])
                            };
                            lst.Add(entKar);
                        }
                    }

                }
                
            }
                return lst;
        } 
        public static void InsertKardex(EntidadKardex entKdx)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_KARDEX(codigo_item_catalogo,codigo_almacen,id_grupo,id_clase,id_unidad_negocio,cantidad_para_almacenar,stock_minimo,precio_global_almacenamiento,cantidad_para_despachar,precio_unitario_despacho,factor_conversion_equivalencia,fecha_vencimiento ) VALUES('" + entKdx.codigo_item_catalogo+"','"+entKdx.codigo_almacen+"','"+entKdx.id_grupo+"','"+entKdx.id_clase+"','"+entKdx.id_unidad_negocio+ "','" + entKdx.cantidad_para_almacenar + "' ,'" + entKdx.stock_minimo + "'  ,'" + entKdx.precio_global_almacenamiento + "'  ,'" + entKdx.cantidad_para_despachar + "'  ,'" + entKdx.precio_unitario_despacho + "'  ,'" + entKdx.factor_conversion_equivalencia + "'  ,'" + entKdx.fecha_vencimiento + "'  ) ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateKardex(int cantidad_mueve,decimal precio_actual ,string  codigo_item_catalog, int codigo_almacen)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "UPDATE TBL_KARDEX SET cantidad_para_almacenar = cantidad_para_almacenar +'" + cantidad_mueve + "',precio_global_almacenamiento='" + precio_actual + "' WHERE codigo_item_catalogo='" + codigo_item_catalog + "' AND codigo_almacen='"+ codigo_almacen + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateKardex(decimal precio,string codigo_item_catalogo)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "UPDATE TBL_KARDEX SET precio_global_almacenamiento='" + precio+"' WHERE codigo_item_catalogo='"+codigo_item_catalogo+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteKardex(EntidadKardex entKdx)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "DELETE FROM TBL_KARDEX WHERE codigo_item_catalogo='"+entKdx.codigo_item_catalogo+"' AND codigo_almacen='"+entKdx.codigo_almacen+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void ActualizaStockMinimo(int sockMin,decimal precio_actual, string coditem_catalogo)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "UPDATE TBL_KARDEX SET stock_minimo = '" + sockMin + "',precio_global_almacenamiento='" + precio_actual + "' WHERE codigo_item_catalogo='" + coditem_catalogo + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
 
    }
}
