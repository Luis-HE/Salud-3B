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
   public class DatosReporteMovimientoCatalogo
    {
        public static List<EntidadReporteMovimientoCatalogo> ListReporteMovCatalogo(string cod_item_catalogo)
        {
            List<EntidadReporteMovimientoCatalogo> lst = new List<EntidadReporteMovimientoCatalogo>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = @"SELECT TBL_CATALOGO.codigo_item_catalogo as Cod, CONVERT(varchar(11),fecha_mov,106) as Fecha,motivo +' con Documento N° '+ numero_documento as Descrip,cantidad as Entra,precio_entrada as Pre_entra,cantidad*precio_entrada as Total_entra,0 as Sale,0 as Pre_sale,0 as Total_sale,'' as Cantidad_existe,'' as Precio_existe,'' as Total_existe  FROM TBL_CATALOGO INNER JOIN TBL_MOVIMIENTO_CATALOGO
                                ON TBL_CATALOGO.codigo_item_catalogo = TBL_MOVIMIENTO_CATALOGO.codigo_item_catalogo
                                WHERE tipo_movimiento='Entrada' AND TBL_CATALOGO.codigo_item_catalogo='" + cod_item_catalogo + "'  UNION ALL SELECT TBL_CATALOGO.codigo_item_catalogo as Cod, CONVERT(varchar(11),fecha_mov,106) AS Fecha,motivo +' con Documento N° '+ numero_documento as Descrip,0 as Entra,0 as Pre_entra,0 as Total_entra,cantidad as Sale,precio_entrada as Pre_sale,cantidad*precio_entrada as Total_sale,'' as Cantidad_existe,'' as Precio_existe,'' as Total_existe FROM TBL_CATALOGO INNER JOIN TBL_MOVIMIENTO_CATALOGO  ON TBL_CATALOGO.codigo_item_catalogo = TBL_MOVIMIENTO_CATALOGO.codigo_item_catalogo WHERE tipo_movimiento='Salida' AND TBL_CATALOGO.codigo_item_catalogo= '" + cod_item_catalogo + "'  ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadReporteMovimientoCatalogo entMovCatal = new EntidadReporteMovimientoCatalogo()
                            {
                                fecha_mov = dr["Fecha"].ToString(),
                                descripcion = dr["Descrip"].ToString(),
                                cant_entra = Convert.ToInt32(dr["Entra"]),
                                precio_entra = Convert.ToDecimal(dr["Pre_entra"]),
                                total_entra = Convert.ToDecimal(dr["Total_entra"]),
                                cant_sale = Convert.ToInt32(dr["Sale"]),
                                precio_sale = Convert.ToDecimal(dr["Pre_sale"]),
                                total_sale = Convert.ToDecimal(dr["Total_sale"]),
                                cant_existe = dr["Cantidad_existe"].ToString(),
                                precio_existe = dr["Precio_existe"].ToString(),
                                total_existe = dr["Total_existe"].ToString()
                            };
                            lst.Add(entMovCatal);
                        }
                    }
                }

            }

            return lst;
        }
    }
}
