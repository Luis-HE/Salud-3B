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
   public  class Datos_TBL_HC_FESP_NOTA_ENFERMERIA
    {
        public static void CreateNOTAS_ENFERMERIA(Entidad_TBL_HC_FESP_NOTA_ENFERMERIA ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_HC_FESP_NOTA_ENFERMERIA(id_nota_enfermeria,fecha_registro,hora_registro,id_registro_hospitalizacion,numero_historia_clinica,numero_doc_cliente,codigo_persona,id_cama,id_piso,evolucion_enfermeria,dni_empleado,codigo_persona_pago ) values('" + ent.id_nota_enfermeria + "','" + ent.fecha_registro + "','" + ent.hora_registro + "','" + ent.id_registro_hospitalizacion + "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.id_cama + "','" + ent.id_piso + "','" + ent.evolucion_enfermeria + "','" + ent.dni_empleado + "','" + ent.codigo_persona_pago + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Entidad_TBL_HC_FESP_NOTA_ENFERMERIA> ListNOTAS_ENFERMERIA()
        {
            List<Entidad_TBL_HC_FESP_NOTA_ENFERMERIA> lst = new List<Entidad_TBL_HC_FESP_NOTA_ENFERMERIA>();

            return lst;
        }
        public static void UPdateNOTAS_ENFERMERIA(Entidad_TBL_HC_FESP_NOTA_ENFERMERIA ent)
        {

        }
        public static void DeteleNOTAS_ENFERMERIA(int id_registro)
        {

        }
    }
}
