using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

using CapaEntidad;

namespace CapaDatos
{
  public  class DatosNacionalidad
    {
        public static List<EntidadNacionalidad> ListNaciones()
        {
            List<EntidadNacionalidad> lst = new List<EntidadNacionalidad>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "select codigo_nacionalidad,nombre_nacionalidad,nombre_pais from TBL_NACIONALIDAD order by codigo_nacionalidad ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadNacionalidad entNacionalidad = new EntidadNacionalidad()
                            {
                                cod_nacionalidad= Convert.ToInt32(dr["codigo_nacionalidad"]),
                                nomb_nacionalidad =dr["nombre_nacionalidad"].ToString(),
                                nomb_pais = dr["nombre_pais"].ToString()

                            };
                            lst.Add(entNacionalidad);
                        }
                    }

                }
            }
            return lst;
        }
    }
}
