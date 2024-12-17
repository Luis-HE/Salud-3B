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
   public class DatosGuiaRemision
    {
        public static void CreateGuiaRemision(EntidadGuiaRemision entGuiaRem)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "INSERT INTO PRUEBAGRID(columna1,columna2,columna3,columna4) VALUES('" + entGuiaRem.columna1 + "','" + entGuiaRem.columna2 + "','" + entGuiaRem.columna3 + "','" + entGuiaRem.columna4 + "') ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<EntidadGuiaRemision> ReadGuiaRemision()
        {
            List<EntidadGuiaRemision> lst = new List<EntidadGuiaRemision>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "SELECT columna1,columna2,columna3,columna4 FROM PRUEBAGRID ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EntidadGuiaRemision entGuiaRem = new EntidadGuiaRemision()
                        {
                            columna1 = dr["columna1"].ToString(),
                            columna2 = dr["columna2"].ToString(),
                            columna3 = Convert.ToDecimal(dr["columna3"]),
                            columna4 = Convert.ToInt32(dr["columna4"])
                        };
                        lst.Add(entGuiaRem);
                    }
                }
            }
            return lst;
        }
        public static void UpdateGuiaRemision(EntidadGuiaRemision entGuiaRem)
        {

        }
        public static void DeleteGuiaRemision(EntidadGuiaRemision entGuiaRem)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "DELETE FROM PRUEBAGRID WHERE columna1='"+entGuiaRem.columna1+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
