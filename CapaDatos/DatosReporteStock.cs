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
   public class DatosReporteStock
    {
        public static List<EntidadReporteStock> ListReporteStock()
        {
            List<EntidadReporteStock> lst = new List<EntidadReporteStock>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = @"select TBL_CATALOGO.codigo_item_catalogo as codigoItem,descripcion_principal,stock_minimo,cantidad,siglas,precio_actual,precio_actual*cantidad AS costo,descripcion_secundaria from 
                                TBL_UNIDAD_MEDIDA inner join(TBL_CATALOGO right join TBL_KARDEX on TBL_CATALOGO.codigo_item_catalogo = TBL_KARDEX.codigo_item_catalogo)
                                on TBL_UNIDAD_MEDIDA.codigo_unid_medida = TBL_CATALOGO.codigo_unid_medida order by descripcion_principal";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            EntidadReporteStock entRepStock = new EntidadReporteStock()
                            {
                                codigo_item_catalogo = dr["codigoItem"].ToString(),
                                descripcion_principal = dr["descripcion_principal"].ToString(),
                                stock_minimo = Convert.ToInt32(dr["stock_minimo"]),
                                cantidad = Convert.ToInt32(dr["cantidad"]),
                                Unidad_medida = dr["siglas"].ToString(),
                                precio_actual = Convert.ToDecimal(dr["precio_actual"]),
                                costo_inventario = Convert.ToDecimal(dr["costo"]),
                                descripcion_secundaria = dr["descripcion_secundaria"].ToString(),
                                
                            };
                            lst.Add(entRepStock);
                        }
                    }
                }

            }
                return lst;
        }
    }
}
