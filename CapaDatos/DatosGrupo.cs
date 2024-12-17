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
   public  class DatosGrupo
    {
        public static List<EntidadGrupo> ListGrupo()
        {
            List<EntidadGrupo> lst = new List<EntidadGrupo>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select id_grupo, nombre_grupo from TBL_GRUPO order by id_grupo";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadGrupo entgrp = new EntidadGrupo()
                            {
                                id_grupo = Convert.ToInt32(dr["id_grupo"]),
                                nombre_grupo = dr["nombre_grupo"].ToString()
                            };
                            lst.Add(entgrp);
                        }
                    }

                }
            }

            return lst;
        }
    }
}
