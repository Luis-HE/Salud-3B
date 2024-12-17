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
  public  class DatosUsuario
    {
        public static void CreateUsuario(EntidadUsuario entUsuario)
        {
          
        }
        public static List<EntidadUsuario> ReadUsuario( string NombreUsuario, string Clave)
        {
            List<EntidadUsuario> lst = new List<EntidadUsuario>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "SELECT nombre_usuario,nivel_acceso from TBL_USUARIO where nombre_usuario='" + NombreUsuario + "' and clave='" + Clave + "'";
                
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadUsuario entUser = new EntidadUsuario()
                            {
                                NombreUsuario = dr["nombre_usuario"].ToString(),
                                nivel_acceso = Convert.ToInt32(dr["nivel_acceso"])
                            };
                            lst.Add(entUser);
                        }
                    }
                        
                }
            }
            return lst;
        }
        public static void UpdateUsuario(EntidadUsuario entUsuario)
        {

        }
        public static void DeleteUsuario(EntidadUsuario entUsuario)
        {
             
        }
         
    }
}
