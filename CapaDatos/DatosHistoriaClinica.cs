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
   public class DatosHistoriaClinica
    {
        public static void InsertarHistoriaClinica(EntidadHistoriaClinica enthc)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_HISTORIA_CLINICA(numero_hist_clinica,fecha_creacion,numero_doc_cliente,codigo_persona,persona_crea) VALUES('"+enthc.num_hist_clinica+"','"+enthc.fecha_creacion+"','"+enthc.num_doc_cliente+"','"+enthc.codigo_persona+"','"+enthc.persona_crea+"' ) ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
