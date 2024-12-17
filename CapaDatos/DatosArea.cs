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
   public  class DatosArea
    {
        public static List<EntidadArea> ListArea()
        {
            List<EntidadArea> lst = new List<EntidadArea>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "SELECT codigo_area,nombre_area FROM TBL_AREA";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadArea entarea = new EntidadArea()
                            {
                                id_area = Convert.ToInt32(dr["codigo_area"]),
                                nombre_area = dr["nombre_area"].ToString()
                            };
                            lst.Add(entarea);
                        }
                    }

                }
            }
            return lst;
        }
    }
}
