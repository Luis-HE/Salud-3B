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
   public  class DatosUnidadNegocio
    {
        public static List<EntidadUnidadNegocio> ReadUnidadNegocio()
        {
            List<EntidadUnidadNegocio> lst = new List<EntidadUnidadNegocio>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "select id_unidad_negocio,nombre_unid_negocio,ubicacion_local from TBL_UNIDAD_NEGOCIO ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadUnidadNegocio entUM = new EntidadUnidadNegocio()
                            {
                                id_unidad_negocio = Convert.ToInt32(dr["id_unidad_negocio"]),
                                nombre_unid_negocio = dr["nombre_unid_negocio"].ToString(),
                                ubicacion_local = dr["ubicacion_local"].ToString()
                            };
                            lst.Add(entUM);
                        }
                    }

                }
            }
            return lst;
        }
    }
}
