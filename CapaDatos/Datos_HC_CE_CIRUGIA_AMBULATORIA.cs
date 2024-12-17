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
  public   class Datos_HC_CE_CIRUGIA_AMBULATORIA
    {
        public static void InsertarCirugiaAmbulatoria(Entidad_HC_CE_CIRUGIA_AMBULATORIA ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_HC_CE_CIRUGIA_AMBULATORIA(id_cirugia_ambulatoria,numero_historia_clinica,numero_doc_cliente,codigo_persona,numero_admision,fecha_atencion,hora_atencion,anamnesis,antecedentes,examen_fisico,desarrollo_psicomotor,examenes,cod_cie_diez, tratamiento, operacion,indicaciones,evolucion_postoperatoria,indicaciones_alta,dni_empleado ) values('" + ent.id_cirugia_ambulatoria + "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.numero_admision + "','" + ent.fecha_atencion + "','" + ent.hora_atencion + "','" + ent.anamnesis + "','" + ent.antecedentes + "','" + ent.examen_fisico + "','" + ent.desarrollo_psicomotor + "' ,'" + ent.examenes + "','" + ent.cod_cie_diez + "','" + ent.tratamiento + "','" + ent.operacion + "' ,'" + ent.indicaciones + "','" + ent.evolucion_postoperatoria + "','" + ent.indicaciones_alta + "','" + ent.dni_empleado + "','" + ent.codigo_persona_pago + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
