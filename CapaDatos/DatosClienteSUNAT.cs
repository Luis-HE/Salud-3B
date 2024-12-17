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
  public  class DatosClienteSUNAT
    {
        public static List<EntidadClienteSUNAT> listarClienteSUNAT(string numero_documento, string serie, string tipo_documento)
        {
            List<EntidadClienteSUNAT> lst = new List<EntidadClienteSUNAT>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "spClienteSUNAT";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@numero_documento", SqlDbType.VarChar, 16)).Value = numero_documento;
                    cmd.Parameters.Add(new SqlParameter("@serie", SqlDbType.VarChar, 16)).Value = serie;
                    cmd.Parameters.Add(new SqlParameter("@tipo_documento", SqlDbType.Char, 2)).Value = tipo_documento;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadClienteSUNAT ent = new EntidadClienteSUNAT()
                            {
                                col1 = dr["id_diferencia"].ToString(),
                                col2 = dr["tipo_doc_cliente"].ToString(),
                                col3 = dr["ruc_cliente"].ToString(),
                                col4 = dr["nombre_cliente"].ToString(),
                                col5 = dr["NombreComercial"].ToString(),
                                col6 = dr["pais"].ToString(),
                                col7 = dr["ubigeo"].ToString(),
                                col8 = dr["direccion"].ToString(),
                                col9 = dr["telef"].ToString(),
                                col10 = dr["email"].ToString()                              

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
