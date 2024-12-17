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
  public  class DatosLaboratorioDetalle
    {
        public static void InsertarLaboratorioDetalle(EntidadLaboratorioDetalle ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_LABORATORIO_DETALLE(id_reg_det_lab,id_reg_laboratorio,descripcion,valor_resultado,numero_historia_clinica,numero_doc_cliente,codigo_persona) VALUES( (SELECT ISNULL(MAX(id_reg_det_lab),0)+1 FROM TBL_LABORATORIO_DETALLE)  ,'" + ent.id_reg_laboratorio + "','" + ent.descripcion + "','" + ent.valor_resultado + "','" + ent.numero_historia_clinica + "','" + ent.num_doc_cliente + "' , '" + ent.codigo_persona + "' ) ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
