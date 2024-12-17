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
  public  class Datos_HC_DG_DIAGNOSTICO
    {
        public static void InsertarDiagnostico(Entidad_HC_DG_DIAGNOSTICO ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_HC_DG_DIAGNOSTICO(id_diagnostico,numero_historia_clinica,numero_doc_cliente,codigo_persona,cod_cie_diez,codigo_especialidad,descripcion_diagnostico,fecha_registro,hora_registro,dni_empleado,codigo_persona_pago,tipo_diagnostico ) VALUES( '"+ent.id_diagnostico+ "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "', '" + ent.codigo_persona + "', '" + ent.cod_cie_diez + "', '" + ent.codigo_especialidad + "', '" + ent.descripcion_diagnostico + "', '" + ent.fecha_registro + "', '" + ent.hora_registro + "', '" + ent.dni_empleado + "', '" + ent.codigo_persona_pago + "', '" + ent.tipo_diagnostico + "'  ) ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
