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
   public  class Datos_HC_EM_ATENCION_EMERGENCIA
    {
        public static void CreateATENCION_EMERGENCIA(Entidad_HC_EM_ATENCION_EMERGENCIA ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_HC_EM_ATENCION_EMERGENCIA(id_atencion_emergencia,numero_historia_clinica,numero_doc_cliente,codigo_persona,dni_empleado,codigo_persona_pago,numero_admision,fecha_atencion,hora_atencion,filiacion,anamnesis_enfermedad_actual,antecedentes,examen_fisico,id_consentimiento_informado,id_autoriza_procedimiento_quirurgico,examenes_auxiliares,diagnostico_presuntivo,plan_trabajo,terapeutica_seguimiento,epicrisis_resumen_historia,id_materno_perinatal,id_partograma,prioridad) values('" + ent.id_atencion_emergencia + "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.dni_empleado + "','" + ent.codigo_persona_pago + "','" + ent.numero_admision + "','" + ent.fecha_atencion + "','" + ent.hora_atencion + "','" + ent.filiacion + "','" + ent.anamnesis_enfermedad_actual + "','" + ent.antecedentes + "','" + ent.examen_fisico + "' ,'" + ent.id_consentimiento_informado + "','" + ent.id_autoriza_procedimiento_quirurgico + "','" + ent.examenes_auxiliares + "','" + ent.diagnostico_presuntivo + "' ,'" + ent.plan_trabajo + "','" + ent.terapeutica_seguimiento + "','" + ent.epicrisis_resumen_historia + "','" + ent.id_materno_perinatal + "','" + ent.id_partograma + "','" + ent.prioridad + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Entidad_HC_EM_ATENCION_EMERGENCIA> ListATENCION_EMERGENCIA()
        {
            List<Entidad_HC_EM_ATENCION_EMERGENCIA> lst = new List<Entidad_HC_EM_ATENCION_EMERGENCIA>();

            return lst;
        }
        public static void UPdateATENCION_EMERGENCIA(Entidad_HC_EM_ATENCION_EMERGENCIA ent)
        {

        }
        public static void DeteleATENCION_EMERGENCIA(int id_registro)
        {

        }
    }
}
