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
   public class DatosTarifario
    {
        public static List<EntidadTarifario> ListTarifario(int cod_categoria,int id_cia_seg,int id_grupo)
        {
            List<EntidadTarifario> lst = new List<EntidadTarifario>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "SELECT TBL_CATALOGO.codigo_item_catalogo AS codItem, descripcion_principal,precio,precio_venta  FROM TBL_CATALOGO INNER JOIN TBL_CONVENIO_DETALLE ON TBL_CATALOGO.codigo_item_catalogo = TBL_CONVENIO_DETALLE.codigo_item_catalogo WHERE codigo_categoria = '"+ cod_categoria + "' and id_cia_seguro = '" + id_cia_seg + "' and TBL_CATALOGO.id_grupo='"+id_grupo+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        EntidadTarifario enttarf = new EntidadTarifario()
                        {
                            cod_item_catalogo=dr["codItem"].ToString(),
                            descripcion_principal = dr["descripcion_principal"].ToString(),
                            precio_base = Convert.ToDecimal(dr["precio"]),
                            precio_venta = Convert.ToDecimal(dr["precio_venta"])
                        };
                        lst.Add(enttarf);
                    }

                }

            }
                return lst;
        }
        public static List<EntidadTarifario> ListTarifario(int cod_categoria, int id_grupo)
        {
            List<EntidadTarifario> lst = new List<EntidadTarifario>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "SELECT TBL_CATALOGO.codigo_item_catalogo AS codItem, descripcion_principal,precio,precio_global_almacenamiento FROM TBL_CATALOGO INNER JOIN TBL_KARDEX ON TBL_CATALOGO.codigo_item_catalogo = TBL_KARDEX.codigo_item_catalogo WHERE codigo_categoria = '" + cod_categoria+"' and TBL_CATALOGO.id_grupo = '"+id_grupo+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EntidadTarifario enttarf = new EntidadTarifario()
                        {
                            cod_item_catalogo = dr["codItem"].ToString(),
                            descripcion_principal = dr["descripcion_principal"].ToString(),
                            precio_base = Convert.ToDecimal(dr["precio"]),
                            precio_venta = Convert.ToDecimal(dr["precio_global_almacenamiento"])
                        };
                        lst.Add(enttarf);
                    }

                }

            }
            return lst;
        }
    }
}
