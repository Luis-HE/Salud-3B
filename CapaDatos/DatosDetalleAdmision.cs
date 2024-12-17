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
  public  class DatosDetalleAdmision
    {
        public static List<EntidadDetalleAdmision> ListDetalleAdmision(int numero_admision)
        {
            List<EntidadDetalleAdmision> lst = new List<EntidadDetalleAdmision>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "SELECT id_reg_det_atencion,numero_admision,codigo_item_catalogo,descripcion_item,precio_atendido,estado,codigo_especialidad FROM TBL_ADMISION_DETALLE WHERE numero_admision='" + numero_admision + "'";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            EntidadDetalleAdmision entdetAdm = new EntidadDetalleAdmision()
                            {
                                id_reg_det_admision = Convert.ToInt32(dr["id_reg_det_atencion"]),
                                num_admision = Convert.ToInt32( dr["numero_admision"]),
                                codigo_item = dr["codigo_item_catalogo"].ToString(),
                                descrip_item = dr["descripcion_item"].ToString(),
                                precio_atencion = Convert.ToDecimal(dr["precio_atendido"]),
                                estado = dr["estado"].ToString(),                                                  
                                codigo_especialidad = Convert.ToInt32(dr["codigo_especialidad"])

                            };
                            lst.Add(entdetAdm);
                        }

                    }

                }
                

            }
                return lst;
        }
        public static void InsertDetalleAdmision(EntidadDetalleAdmision entDetAdm)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_ADMISION_DETALLE(id_reg_det_atencion,numero_admision,codigo_item_catalogo,estado,descripcion_item,precio_atendido,hora,codigo_especialidad,id_grupo,id_clase) VALUES((SELECT ISNULL(MAX(id_reg_det_atencion),0)+1 FROM TBL_ADMISION_DETALLE),'" + entDetAdm.num_admision+"','"+entDetAdm.codigo_item+"','"+entDetAdm.estado+"','"+entDetAdm.descrip_item+"','"+entDetAdm.precio_atencion+"','"+entDetAdm.hora+"','"+entDetAdm.codigo_especialidad+ "','" + entDetAdm.id_grupo + "','" + entDetAdm.id_clase + "')";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
