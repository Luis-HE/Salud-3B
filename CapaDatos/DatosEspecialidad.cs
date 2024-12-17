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
   public class DatosEspecialidad
    {
        public static List<EntidadEspecialidad> ListEspecialidad()
        {
            List<EntidadEspecialidad> lst = new List<EntidadEspecialidad>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select codigo_especialidad,nombre_especialidad from TBL_ESPECIALIDAD order by codigo_especialidad";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadEspecialidad entEspec = new EntidadEspecialidad()
                            {
                                cod_especialidad = Convert.ToInt32(dr["codigo_especialidad"]),
                                nom_especialidad = dr["nombre_especialidad"].ToString()
                            };
                            lst.Add(entEspec);
                        }
                    }
                   
                }

            }

                return lst;
        }
    }
}
