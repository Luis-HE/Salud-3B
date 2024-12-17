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
   public class DatosUnidadMedida
    {
        public static void CreateUnidadMedida(EntidadUnidadMedida entUnMed)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "INSERT INTO  TBL_UNIDAD_MEDIDA(nombre_unid_medida,siglas,codigo_unidad_sunat) VALUES('"+entUnMed.nombre_medida+"','"+entUnMed.siglas+"','"+entUnMed.cod_unidad_sunat+"') ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                   
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<EntidadUnidadMedida> ReadUnidadMedida()
        {
            List<EntidadUnidadMedida> lst = new List<EntidadUnidadMedida>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "select codigo_unid_medida,nombre_unid_medida,siglas,codigo_unidad_sunat from TBL_UNIDAD_MEDIDA order by nombre_unid_medida ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadUnidadMedida entUser = new EntidadUnidadMedida()
                            {
                                cod_unidad_medida = Convert.ToInt32(dr["codigo_unid_medida"]),
                                nombre_medida = dr["nombre_unid_medida"].ToString(),
                                siglas = dr["siglas"].ToString(),
                                cod_unidad_sunat = dr["codigo_unidad_sunat"].ToString()
                            };
                            lst.Add(entUser);
                        }
                    }

                }
            }
            return lst;
        }
        public static void UpdateUnidadMedida(EntidadUnidadMedida entUnMed)
        {

        }
        public static void DeleteUnidadMedida(EntidadUnidadMedida entUnMed)
        {

        }
    }
}
