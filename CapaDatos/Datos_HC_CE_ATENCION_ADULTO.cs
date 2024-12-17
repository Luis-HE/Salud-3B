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
   public  class Datos_HC_CE_ATENCION_ADULTO
    {
        public static void CreateATENCION_ADULTO(Entidad_HC_CE_ATENCION_ADULTO ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_HC_CE_ATENCION_ADULTO(id_atencion_adulto,numero_historia_clinica,numero_doc_cliente,codigo_persona,numero_admision,fecha_atencion,hora_atencion,grado_instruccion,centro_educativo,ocupacion,antecedentes_personales,antecedentes_familiares,alergia_medicamentos,sexualidad,salud_bucal,motivo_consulta,tiempo_enfermedad,funciones_biologicas,examen_fisico,cod_cie_diez,tratamiento,examenes_auxiliares,referencia,fecha_proxima_cita,dni_empleado,codigo_persona_pago ) values('" + ent.id_atencion_adulto + "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.numero_admision + "','" + ent.fecha_atencion + "','" + ent.hora_atencion + "','" + ent.grado_instruccion + "','" + ent.centro_educativo + "','" + ent.ocupacion + "','" + ent.antecedentes_personales + "' ,'" + ent.antecedentes_familiares + "','" + ent.alergia_medicamentos + "','" + ent.sexualidad + "','" + ent.salud_bucal + "' ,'" + ent.motivo_consulta + "','" + ent.tiempo_enfermedad + "','" + ent.funciones_biologicas + "','" + ent.examen_fisico + "','" + ent.cod_cie_diez + "','" + ent.tratamiento + "','" + ent.examenes_auxiliares + "','" + ent.referencia + "','" + ent.fecha_proxima_cita + "','" + ent.dni_empleado + "','" + ent.codigo_persona_pago + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Entidad_HC_CE_ATENCION_ADULTO> ListATENCION_ADULTO()
        {
            List<Entidad_HC_CE_ATENCION_ADULTO> lst = new List<Entidad_HC_CE_ATENCION_ADULTO>();

            return lst;
        }
        public static void UPdateATENCION_ADULTO(Entidad_HC_CE_ATENCION_ADULTO ent)
        {

        }
        public static void DeteleATENCION_ADULTO(int id_registro)
        {

        }
    }
}
