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
  public  class Datos_HC_Lista_Atenciones
    {
        public static List<Entidad_HC_Lista_Atenciones> ListarAtencionesHC( string numero_dni)
        {
            List<Entidad_HC_Lista_Atenciones> lst = new List<Entidad_HC_Lista_Atenciones>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "spListarAtencionesHC";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@numero_doc_cliente", SqlDbType.VarChar, 15)).Value = numero_dni;
                   using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Entidad_HC_Lista_Atenciones ent = new Entidad_HC_Lista_Atenciones()
                            {
                                col1 = dr["asistencia"].ToString(),
                                col2 = dr["numero_admision"].ToString(),
                                col3 = dr["fecha_admision"].ToString(),
                                col4 = dr["tipo_admision"].ToString(),
                                col5 = dr["nombre_especialidad"].ToString(),
                                col6 = dr["numero_doc_cliente"].ToString(),
                                col7 = dr["Paciente"].ToString()

                            };
                            lst.Add(ent);
                        }
                    }

                }

            }
            return lst;
        }
    }
}
