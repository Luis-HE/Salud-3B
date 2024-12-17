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
   public class DatosEmergencia
    {
        public static void InsertarEmergencia(EntidadEmergencia entEmerg)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_EMERGENCIA(id_emergencia,numero_hist_clinica,numero_doc_cliente,codigo_persona,numero_admision,medico_tratante,condicion_paciente,prioridad,forma_inicio,tiempo_enfermedad,sintomas_principales,relato_cronologico,antecedentes,apreciacion_general,dni_empleado,codigo_persona_pago,fecha_atencion,fecha_consulta_externa) VALUES('"+entEmerg.id_emergencia+ "','" + entEmerg.num_hist_clinica + "','" + entEmerg.num_doc_cliente + "','" + entEmerg.cod_persona + "','" + entEmerg.numero_admision + "','" + entEmerg.medico_tratante + "','" + entEmerg.condicion_paciente + "','" + entEmerg.prioridad + "','" + entEmerg.forma_inicio + "','" + entEmerg.tiempo_enfermedad + "','" + entEmerg.sintomas_principales + "','" + entEmerg.relato_cronologico + "','" + entEmerg.antecedentes + "','" + entEmerg.apreciacion_general + "','" + entEmerg.dni_empleado + "','" + entEmerg.cod_persona_pago + "','" + entEmerg.fecha_atencion + "','" + entEmerg.fecha_consulta_externa + "' ) ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
