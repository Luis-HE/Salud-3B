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
   public  class Datos_HC_CE_ATENCION_ADOLECENTE
    {
        public static void CreateATENCION_ADOLECENTE(Entidad_HC_CE_ATENCION_ADOLECENTE ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_HC_CE_ATENCION_ADOLECENTE(id_atencion_adolecente,numero_historia_clinica,numero_doc_cliente,codigo_persona,numero_admision,fecha_atencion,hora_atencion,edad,grado_instruccion,centro_educativo,ocupacion,id_reg_acompanante,antecedentes_personales,antecedentes_familiares,antecedentes_psicosociales,salud_sexual_reproductiva,salud_bucal,motivo_consulta,tiempo_enfermedad,funciones_biologicas,evaluacion_antropometrica,evaluacion_riesgo_cardiovascular,funciones_vitales,examen_fisico,cod_cie_diez,tratamiento,examenes_auxiliares,referencia,fecha_proxima_cita,dni_empleado,codigo_persona_pago ) values('" + ent.id_atencion_adolecente + "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.numero_admision + "','" + ent.fecha_atencion + "','" + ent.hora_atencion + "','" + ent.edad + "','" + ent.grado_instruccion + "','" + ent.centro_educativo + "','" + ent.ocupacion + "','" + ent.id_reg_acompanante + "','" + ent.antecedentes_personales + "' ,'" + ent.antecedentes_familiares + "','" + ent.antecedentes_psicosociales + "','" + ent.salud_sexual_reproductiva + "','" + ent.salud_bucal + "' ,'" + ent.motivo_consulta + "','" + ent.tiempo_enfermedad + "','" + ent.funciones_biologicas + "','" + ent.evaluacion_antropometrica + "','" + ent.evaluacion_riesgo_cardiovascular + "','" + ent.funciones_vitales + "','" + ent.examen_fisico + "','" + ent.cod_cie_diez + "','" + ent.tratamiento + "','" + ent.examenes_auxiliares + "','" + ent.referencia + "','" + ent.fecha_proxima_cita + "','" + ent.dni_empleado + "','" + ent.codigo_persona_pago + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Entidad_HC_CE_ATENCION_ADOLECENTE> ListATENCION_ADOLECENTE()
        {
            List<Entidad_HC_CE_ATENCION_ADOLECENTE> lst = new List<Entidad_HC_CE_ATENCION_ADOLECENTE>();

            return lst;
        }
        public static void UPdateATENCION_ADOLECENTE(Entidad_HC_CE_ATENCION_ADOLECENTE ent)
        {

        }
        public static void DeteleATENCION_ADOLECENTE(int id_registro)
        {

        }
    }
}
