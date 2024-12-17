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
   public class Datos_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN
    {
        public static void CreatePATOLOGIA_SOLICITUD_EXAMEN(Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query =  "insert into TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN(id_patologia_solicitud_examen,numero_historia_clinica,numero_doc_cliente,codigo_persona,numero_admision,fecha_registro,dni_empleado,codigo_persona_pago,motivo_solicitud,edad_paciente,indicaciones_medicas,diagnostico_presuntivo ) values('" + ent.id_patologia_solicitud_examen + "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.numero_admision + "','" + ent.fecha_registro + "','" + ent.dni_empleado + "','" + ent.codigo_persona_pago + "','" + ent.motivo_solicitud + "','" + ent.edad_paciente + "','" + ent.indicaciones_medicas + "' ,'" + ent.diagnostico_presuntivo + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static List<Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN> ListPATOLOGIA_SOLICITUD_EXAMEN()
        {
            List<Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN> lst = new List<Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN>();

            return lst;
        }
        public static void UPdatePATOLOGIA_SOLICITUD_EXAMEN(Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN ent)
        {

        }
        public static void DetelePATOLOGIA_SOLICITUD_EXAMEN(int id_solicitud_examen)
        {

        }
    }
}
