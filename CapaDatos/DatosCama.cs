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
   public class DatosCama
    {
        public static List<EntidadCama> ListCamas()
        {
            List<EntidadCama> lst = new List<EntidadCama>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select id_cama,descripcion,ubicacion,estado from TBL_CAMA ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadCama entCama = new EntidadCama()
                            {
                                id_cama = Convert.ToInt32(dr["id_cama"]),
                                descripcion = dr["descripcion"].ToString(),
                                ubicacion = dr["ubicacion"].ToString(),
                                estado = dr["estado"].ToString()
                            };
                            lst.Add(entCama);
                        }
                    }

                }
            }
            return lst;
        }
    }
}
