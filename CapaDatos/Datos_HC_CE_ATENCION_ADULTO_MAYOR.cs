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
   public  class Datos_HC_CE_ATENCION_ADULTO_MAYOR
    {
        public static void CreateATENCION_ADULTO_MAYOR(Entidad_HC_CE_ATENCION_ADULTO_MAYOR ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_HC_CE_ATENCION_ADULTO_MAYOR(id_atencion_adulto_mayor,numero_historia_clinica,numero_doc_cliente,codigo_persona,numero_admision,fecha_atencion,hora_atencion,grado_instruccion,ocupacion,id_reg_acompanante,antecedentes_personales,antecedentes_familiares,alergia_medicamentos,medicamentos_frecuentes,reaccion_adversa_medicamentos,valoracion_clinica,categorias_adulto_mayor,salud_bucal,motivo_consulta,tiempo_enfermedad,funciones_biologicas,examen_fisico,tratamiento,examenes_auxiliares,referencia,fecha_proxima_cita,dni_empleado,codigo_persona_pago,cod_cie_diez ) values('" + ent.id_atencion_adulto_mayor + "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.numero_admision + "','" + ent.fecha_atencion + "','" + ent.hora_atencion + "','" + ent.grado_instruccion + "','" + ent.ocupacion + "','" + ent.id_reg_acompanante + "','" + ent.antecedentes_personales + "' ,'" + ent.antecedentes_familiares + "','" + ent.alergia_medicamentos + "','" + ent.medicamentos_frecuentes + "','" + ent.reaccion_adversa_medicamentos + "','" + ent.valoracion_clinica + "','" + ent.categorias_adulto_mayor + "','" + ent.salud_bucal + "' ,'" + ent.motivo_consulta + "','" + ent.tiempo_enfermedad + "','" + ent.funciones_biologicas + "','" + ent.examen_fisico + "','" + ent.tratamiento + "','" + ent.examenes_auxiliares + "','" + ent.referencia + "','" + ent.fecha_proxima_cita + "','" + ent.dni_empleado + "','" + ent.codigo_persona_pago + "','" + ent.cod_cie_diez + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Entidad_HC_CE_ATENCION_ADULTO_MAYOR> ListATENCION_ADULTO_MAYOR()
        {
            List<Entidad_HC_CE_ATENCION_ADULTO_MAYOR> lst = new List<Entidad_HC_CE_ATENCION_ADULTO_MAYOR>();

            return lst;
        }
        public static void UPdateATENCION_ADULTO_MAYOR(Entidad_HC_CE_ATENCION_ADULTO_MAYOR ent)
        {

        }
        public static void DeteleATENCION_ADULTO_MAYOR(int id_registro)
        {

        }
    }
}
