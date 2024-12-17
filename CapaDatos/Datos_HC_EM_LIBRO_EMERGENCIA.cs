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
   public  class Datos_HC_EM_LIBRO_EMERGENCIA
    {
        public static void CreateLIBRO_EMERGENCIA(Entidad_HC_EM_LIBRO_EMERGENCIA ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_HC_EM_LIBRO_EMERGENCIA(id_libro_emergencia,numero_historia_clinica,numero_doc_cliente,codigo_persona,dni_empleado,codigo_persona_pago,numero_admision,fecha_ingreso,hora_ingreso,nombre_paciente,edad,genero,direccion_domicilio,diagnostico_ingreso,diagnostico_final,destino_final,hora_termina_atencion,observaciones,nombre_acompanante) values('" + ent.id_libro_emergencia + "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.dni_empleado + "','" + ent.codigo_persona_pago + "','" + ent.numero_admision + "','" + ent.fecha_ingreso + "','" + ent.hora_ingreso + "','" + ent.nombre_paciente + "','" + ent.edad + "','" + ent.genero + "','" + ent.direccion_domiciliaria + "' ,'" + ent.diagnostico_ingreso + "','" + ent.diagnostico_final + "','" + ent.destino_final + "','" + ent.hora_termina_atencion + "' ,'" + ent.observaciones + "','" + ent.nombre_acompanante + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Entidad_HC_EM_LIBRO_EMERGENCIA> ListLIBRO_EMERGENCIA()
        {
            List<Entidad_HC_EM_LIBRO_EMERGENCIA> lst = new List<Entidad_HC_EM_LIBRO_EMERGENCIA>();

            return lst;
        }
        public static void UPdateLIBRO_EMERGENCIA(Entidad_HC_EM_LIBRO_EMERGENCIA ent)
        {

        }
        public static void DeteleLIBRO_EMERGENCIA(int id_registro)
        {

        }
    }
}
