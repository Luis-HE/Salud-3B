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
  public  class DatosCategoria
    {
        public static List<EntidadCategoria> ListCategoria()
        {
            List<EntidadCategoria> lst = new List<EntidadCategoria>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "select codigo_categoria,nombre_categoria from TBL_CATEGORIA order by nombre_categoria ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadCategoria entcat = new EntidadCategoria()
                            {
                                codigo_categoria = Convert.ToInt32(dr["codigo_categoria"]),
                                nombre_categoria = dr["nombre_categoria"].ToString()
                            };
                            lst.Add(entcat);
                        }
                    }

                }
            }
            return lst;
        }

    }
}
