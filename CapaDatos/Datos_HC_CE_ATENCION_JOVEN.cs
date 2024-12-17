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
   public  class Datos_HC_CE_ATENCION_JOVEN
    {
        public static void CreateATENCION_JOVEN(Entidad_HC_CE_ATENCION_JOVEN ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_HC_CE_ATENCION_JOVEN(id_atencion_joven,numero_historia_clinica,numero_doc_cliente,codigo_persona,numero_admision,fecha_atencion,hora_atencion,grado_instruccion,ocupacion,id_reg_acompanante,antecedentes_personales,antecedentes_familiares,antecedentes_psicosociales,salud_sexual_reproductiva,salud_bucal,motivo_consulta,tiempo_enfermedad,funciones_biologicas,evaluacion_antropometrica,evaluacion_riesgo_cardiovascular,funciones_vitales,examen_fisico,cod_cie_diez,tratamiento,examenes_auxiliares,referencia,fecha_proxima_cita,dni_empleado,codigo_persona_pago ) values('" + ent.id_atencion_joven + "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.numero_admision + "','" + ent.fecha_atencion + "','" + ent.hora_atencion + "','" + ent.grado_instruccion + "','" + ent.ocupacion + "','" + ent.id_reg_acompanante + "','" + ent.antecedentes_personales + "' ,'" + ent.antecedentes_familiares + "','" + ent.antecedentes_psicosociales + "','" + ent.salud_sexual_reproductiva + "','" + ent.salud_bucal + "' ,'" + ent.motivo_consulta + "','" + ent.tiempo_enfermedad + "','" + ent.funciones_biologicas + "','" + ent.evaluacion_antropometrica + "','" + ent.evaluacion_riesgo_cardiovascular + "','" + ent.funciones_vitales + "','" + ent.examen_fisico + "','" + ent.cod_cie_diez + "','" + ent.tratamiento + "','" + ent.examenes_auxiliares + "','" + ent.referencia + "','" + ent.fecha_proxima_cita + "','" + ent.dni_empleado + "','" + ent.codigo_persona_pago + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Entidad_HC_CE_ATENCION_JOVEN> ListATENCION_JOVEN()
        {
            List<Entidad_HC_CE_ATENCION_JOVEN> lst = new List<Entidad_HC_CE_ATENCION_JOVEN>();

            return lst;
        }
        public static void UPdateATENCION_JOVEN(Entidad_HC_CE_ATENCION_JOVEN ent)
        {

        }
        public static void DeteleATENCION_JOVEN(int id_registro)
        {

        }
    }
}
