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
   public class DatosMedicoReferente
    {
        public static List<EntidadMedicoReferente> ListMedicoReferente(string apellido_paterno)
        {
            List<EntidadMedicoReferente> lst = new List<EntidadMedicoReferente>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "SELECT cmp, apellido_paterno,apellido_materno,nombres,telefono_fijo,telefono_movil,email,codigo_especialidad FROM TBL_MEDICO_REFERENTE WHERE apellido_paterno LIKE '%"+ apellido_paterno +"%'  ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            EntidadMedicoReferente entmedref = new EntidadMedicoReferente()
                            {
                                cmp= dr[""].ToString(),
                                apellido_paterno = dr[""].ToString(),
                                apellido_materno = dr[""].ToString(),
                                nombres = dr[""].ToString(),
                                telefono_fijo = dr[""].ToString(),
                                telefono_movil = dr[""].ToString(),
                                email = dr[""].ToString(),
                                codigo_especialidad = Convert.ToInt32(dr[""])

                            };
                            lst.Add(entmedref);
                        }
                    }

                }

            }
                return lst;
        }
        
    }
}
