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
   public class DatosUbigeo
    {
        public static List<EntidadUbigeo> ListarUbigeo()
            {
             List<EntidadUbigeo> lst = new List<EntidadUbigeo>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = " SELECT id_ubigeo,nomb_departamento+'-'+nomb_provincia+'-'+distrito as Departamento,nomb_provincia,distrito from TBL_UBIGEO order by nomb_departamento ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadUbigeo entUbg = new EntidadUbigeo()
                            {
                                id_ubigeo =  dr["id_ubigeo"].ToString(),
                                nomb_departamento = dr["Departamento"].ToString(),
                                nomb_provincia = dr["nomb_provincia"].ToString(),
                                nomb_distrito = dr["distrito"].ToString()

                            };
                            lst.Add(entUbg);
                        }
                    }

                }
            }
            return lst;
            }
    }
}
