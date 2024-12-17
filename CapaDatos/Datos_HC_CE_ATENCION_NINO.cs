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
    public class Datos_HC_CE_ATENCION_NINO
    {
        public static void CreateATENCION_NINO(Entidad_HC_CE_ATENCION_NINO ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_HC_CE_ATENCION_NINO(id_atencion_nino,numero_historia_clinica,numero_doc_cliente,codigo_persona,numero_admision,fecha_atencion,hora_atencion,grado_instruccion,id_reg_acompanante,edad,antecedentes_personales,antecedentes_familiares,esquema_vacunacion,vigilancia_crecimiento_desarrollo,anamnesis,problemas_frecuentes_infancia,evaluacion_alimentacion_actual,examen_fisico,cod_cie_diez,tratamiento,examenes_auxiliares,referencia,fecha_proxima_cita,dni_empleado,codigo_persona_pago ) values('" + ent.id_atencion_nino + "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.numero_admision + "','" + ent.fecha_atencion + "','" + ent.hora_atencion + "','" + ent.grado_instruccion + "','" + ent.id_reg_acompanante + "','" + ent.edad + "','" + ent.antecedentes_personales + "' ,'" + ent.antecedentes_familiares + "','" + ent.esquema_vacunacion + "','" + ent.vigilancia_crecimiento_desarrollo + "','" + ent.anamnesis + "' ,'" + ent.problemas_frecuentes_infancia + "','" + ent.evaluacion_alimentacion_actual + "','" + ent.examen_fisico + "','" + ent.cod_cie_diez + "','" + ent.tratamiento + "','" + ent.examenes_auxiliares + "','" + ent.referencia + "','" + ent.fecha_proxima_cita + "','" + ent.dni_empleado + "','" + ent.codigo_persona_pago + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static List<Entidad_HC_CE_ATENCION_NINO> ListATENCION_NINO()
        {
            List<Entidad_HC_CE_ATENCION_NINO> lst = new List<Entidad_HC_CE_ATENCION_NINO>();

            return lst;
        }
        public static void UPdateATENCION_NINO(Entidad_HC_CE_ATENCION_NINO ent)
        {

        }
        public static void DeteleATENCION_NINO(int id_registro_atencion)
        {

        }
    }
}
