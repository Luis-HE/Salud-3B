using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CapaDatos
{
   public  class DatosAnulaDocumentos
    {
        public static void AnularDocumentos(int numero_documento,string tipo_docuento,string serie, int id_unidad_negocio)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "sPAnularDocumento";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@numero_documento", SqlDbType.Int)).Value = numero_documento;
                    cmd.Parameters.Add(new SqlParameter("@tipo_documento", SqlDbType.Char, 2)).Value = tipo_docuento;
                    cmd.Parameters.Add(new SqlParameter("@serie", SqlDbType.VarChar, 6)).Value = serie;
                    cmd.Parameters.Add(new SqlParameter("@id_unidad_negocio", SqlDbType.Int)).Value = id_unidad_negocio;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
