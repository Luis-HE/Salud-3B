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
   public class DatosCatalogo
    {

        //public static List<EntidadCatalogo> ListItemsCatalogo(string codigo_categoria)
        //{
        //    List<EntidadCatalogo> lst = new List<EntidadCatalogo>();
        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
        //    {
        //        string query = "SELECT codigo_item_catalogo,descripcion_principal,precio,descripcion_secundaria,codigo_unid_medida FROM TBL_CATALOGO WHERE codigo_categoria='" + codigo_categoria + "' ORDER BY descripcion_principal ";
        //        con.Open();
        //        using (SqlCommand cmd = new SqlCommand(query, con))
        //        {
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    EntidadCatalogo entCatal = new EntidadCatalogo()
        //                    {
        //                        cod_item_catalogo = dr["codigo_item_catalogo"].ToString(),
        //                        descripcion_principal = dr["descripcion_principal"].ToString(),
        //                        precio = Convert.ToDecimal(dr["precio"]),
        //                        descripcion_secundaria = dr["descripcion_secundaria"].ToString(),
        //                        cod_uni_med = Convert.ToInt32(dr["codigo_unid_medida"])

        //                    };
        //                    lst.Add(entCatal);
        //                }
        //            }

        //        }
        //    }
        //    return lst;
        //}
        public static List<EntidadCatalogo> ListItemsCatalogo(int id_ciaSeg, string descrip_item)
        {
            List<EntidadCatalogo> lst = new List<EntidadCatalogo>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "SELECT TBL_CATALOGO.codigo_item_catalogo AS codItem, descripcion_principal,precio_venta,0 AS cantidad,'' as NomComercial, TBL_CATALOGO.id_grupo as grupo, TBL_CATALOGO.id_clase as clase  FROM TBL_CATALOGO INNER JOIN TBL_CONVENIO_DETALLE ON TBL_CATALOGO.codigo_item_catalogo = TBL_CONVENIO_DETALLE.codigo_item_catalogo WHERE codigo_categoria = 2 and id_cia_seguro = '" + id_ciaSeg + "' AND  descripcion_principal LIKE '%" + descrip_item + "%'  ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadCatalogo entCatal = new EntidadCatalogo()
                            {
                                cod_item_catalogo = dr["codItem"].ToString(),
                                descripcion_principal = dr["descripcion_principal"].ToString(),
                                precio = Convert.ToDecimal(dr["precio_venta"]),
                                cantidad = Convert.ToInt32(dr["cantidad"]),
                                descripcion_secundaria = dr["NomComercial"].ToString(),
                                id_grupo= Convert.ToInt32(dr["grupo"]),
                                id_clase= Convert.ToInt32(dr["clase"])

                            };
                            lst.Add(entCatal);
                        }
                    }

                }
            }
            return lst;
        }
        public static List<EntidadCatalogo> ListItemsCatalogo(int opcion,string tipo_item, string descrip_item)
        {
            List<EntidadCatalogo> lst = new List<EntidadCatalogo>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                  string query = "";

                if (opcion==1)
                {
                     query = @"SELECT TBL_CATALOGO.codigo_item_catalogo AS COD1, descripcion_principal AS DESCRI,precio_global_almacenamiento AS PRECIO,cantidad_para_almacenar,descripcion_secundaria as NomComercial, TBL_CATALOGO.id_grupo as grupo, TBL_CATALOGO.id_clase as clase  FROM TBL_CATALOGO INNER JOIN TBL_KARDEX ON TBL_CATALOGO.codigo_item_catalogo= TBL_KARDEX.codigo_item_catalogo
                                WHERE tipo_item_catalogo = 'Medicamento' AND descripcion_principal LIKE '%" + descrip_item + "%'  ";
                }
                if (opcion==2)
                {
                   query = @"SELECT TBL_CATALOGO.codigo_item_catalogo AS COD1, descripcion_principal AS DESCRI,precio_global_almacenamiento AS PRECIO,cantidad_para_almacenar,descripcion_secundaria as NomComercial, TBL_CATALOGO.id_grupo as grupo, TBL_CATALOGO.id_clase as clase  FROM TBL_CATALOGO INNER JOIN TBL_KARDEX ON TBL_CATALOGO.codigo_item_catalogo= TBL_KARDEX.codigo_item_catalogo
                                        WHERE tipo_item_catalogo = 'Medicamento' AND descripcion_secundaria LIKE '%" + descrip_item + "%'  ";

                }
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                   using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadCatalogo entCatal = new EntidadCatalogo()
                            {
                                cod_item_catalogo = dr["COD1"].ToString(),
                                descripcion_principal = dr["DESCRI"].ToString(),
                                precio = Convert.ToDecimal(dr["PRECIO"]),
                                cantidad = Convert.ToInt32(dr["cantidad_para_almacenar"]),
                                descripcion_secundaria = dr["NomComercial"].ToString(),
                                id_grupo = Convert.ToInt32(dr["grupo"]),
                                id_clase = Convert.ToInt32(dr["clase"])

                            };
                            lst.Add(entCatal);
                        }
                    }

                }
            }
            return lst;

        }
        
        public static List<EntidadCatalogo> CountItemsCatalogo(string tipo_item_catalogo)
        {
            List<EntidadCatalogo> lst = new List<EntidadCatalogo>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "SELECT ISNULL(MAX(CONVERT(int, substring(codigo_item_catalogo,8,5))),0)+1 as AuxCount FROM TBL_CATALOGO where tipo_item_catalogo='"+ tipo_item_catalogo + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadCatalogo entCatal = new EntidadCatalogo()
                            {
                                AuxCountItems = Convert.ToInt32(dr["AuxCount"])

                            };
                            lst.Add(entCatal);
                        }
                    }

                }
            }
            return lst;
        }

        public static void InsertCatalogo(EntidadCatalogo entCatal)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_CATALOGO(codigo_item_catalogo,codigo_color,codigo_categoria,codigo_marca,codigo_unid_medida,codigo_modelo,descripcion_principal,peso,tipo_item_catalogo,estado,codigo_segus,precio,cuenta_contable,descripcion_secundaria) VALUES('" + entCatal.cod_item_catalogo+"','"+entCatal.cod_color+"','"+entCatal.cod_categoria+"','"+entCatal.cod_marca+"','"+entCatal.cod_uni_med+"','"+entCatal.cod_modelo+"','"+entCatal.descripcion_principal+"','"+entCatal.peso+"','"+entCatal.tipo_item+"','"+entCatal.estado+"','"+entCatal.cod_segus+"','"+entCatal.precio+"','"+entCatal.cuenta_contable+"','"+entCatal.descripcion_secundaria+"') ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void ModificarItemCatalogo(EntidadCatalogo entCatal)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "UPDATE TBL_CATALOGO SET descripcion_principal ='" + entCatal.descripcion_principal+ "',descripcion_secundaria='" + entCatal.descripcion_secundaria+ "', codigo_unid_medida='"+entCatal.cod_uni_med+"' WHERE codigo_item_catalogo='" + entCatal.cod_item_catalogo+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void ModificarPrecioCatalogo(decimal precio, string cod_item_catalogo)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "UPDATE TBL_CATALOGO SET precio ='" + precio + "' WHERE codigo_item_catalogo='" + cod_item_catalogo + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void EliminarItemCatalogo(string cod_item_catalogo)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "DELETE FROM TBL_CATALOGO WHERE codigo_item_catalogo='" + cod_item_catalogo + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
