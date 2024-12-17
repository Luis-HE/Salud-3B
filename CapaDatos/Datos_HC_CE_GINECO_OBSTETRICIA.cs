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
   public class Datos_HC_CE_GINECO_OBSTETRICIA
    {
        public static void InsertarGinecoObstetrica(Entidad_HC_CE_GINECO_OBSTETRICIA ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_HC_CE_GINECO_OBSTETRICIA(id_ginecoobstetricia,numero_historia_clinica,numero_doc_cliente,codigo_persona,numero_admision,fecha_registro,hora_registro,edad,gesta,paridad1,paridad2,paridad3,paridad4, fur, fpp,edad_gestacion,antecedentes,motivo_consulta,tiempo_enfermedad,examen_clinico,cod_cie_diez,plan_trabajo,fecha_proxima_cita,observaciones,dni_empleado,codigo_persona_pago,tratamiento ) values('" + ent.id_ginecoobstetricia + "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.numero_admision + "','" + ent.fecha_registro + "','" + ent.hora_registro + "','" + ent.edad + "','" + ent.gesta + "','" + ent.paridad1 + "','" + ent.paridad2 + "','" + ent.paridad3 + "','" + ent.paridad4 + "' ,'" + ent.fur + "' ,'" + ent.fpp + "','" + ent.edad_gestacion + "','" + ent.antecedentes + "','" + ent.motivo_consulta + "','" + ent.tiempo_enfermedad + "','" + ent.examen_clinico + "','" + ent.cod_cie_diez + "' ,'" + ent.plan_trabajo + "','" + ent.fecha_proxima_cita + "','" + ent.observaciones + "','" + ent.dni_empleado + "','" + ent.codigo_persona_pago + "','"+ent.tratamiento+"' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
