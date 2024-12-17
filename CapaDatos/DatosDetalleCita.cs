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
   public class DatosDetalleCita
    {
        public static List<EntidadDetalleCita> ListDetalleCita(int Num_cita)
        {
            List<EntidadDetalleCita> lst = new List<EntidadDetalleCita>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select id_reg_det_cita,id_cita,codigo_item_catalogo,descripcion_item,hora,estado, precio_citado,confirmado,id_grupo,id_clase from TBL_CITA_DETALLE where id_cita='" + Num_cita + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr= cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            EntidadDetalleCita entdetCita = new EntidadDetalleCita()
                            {
                                id_reg_det_cita = Convert.ToInt32(dr["id_reg_det_cita"]),
                                id_cita = Convert.ToInt32(dr["id_cita"]),
                                cod_item_catalogo = dr["codigo_item_catalogo"].ToString(),
                                descrip_item = dr["descripcion_item"].ToString(),
                                hora_cita = dr["hora"].ToString(),
                                estado = dr["estado"].ToString(),
                                precio_cita= Convert.ToDecimal(dr["precio_citado"]),
                                id_grupo = Convert.ToInt32(dr["id_grupo"]),
                                id_clase= Convert.ToInt32(dr["id_clase"]),
                                confirmado = Convert.ToBoolean(dr["confirmado"])
                            };
                            lst.Add(entdetCita);
                        }
                    }

                }

            }

                return lst;
        }
        public static void InsertDetalleCita(EntidadDetalleCita entDetCita)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_CITA_DETALLE(id_reg_det_cita,id_cita,estado,codigo_item_catalogo,descripcion_item,precio_citado,hora,codigo_especialidad,id_grupo,id_clase,confirmado) VALUES((SELECT ISNULL(MAX(id_reg_det_cita),0)+1 FROM TBL_CITA_DETALLE),'" + entDetCita.id_cita + "','"+ entDetCita.estado + "','"+ entDetCita.cod_item_catalogo + "','"+ entDetCita.descrip_item + "','"+ entDetCita.precio_cita + "','"+ entDetCita.hora_cita + "','"+entDetCita.codigo_especialidad+ "','" + entDetCita.id_grupo + "','" + entDetCita.id_clase + "','" + entDetCita.confirmado + "' ) ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public static void ActualizaEstadoDetalleCita(string dni_paciente,int codigo_especialidad,string hora, string fecha_cita)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = @"UPDATE TBL_CITA_DETALLE SET estado='Cancelado' where id_reg_det_cita =(select id_reg_det_cita from TBL_CITA INNER JOIN TBL_CITA_DETALLE ON TBL_CITA.id_cita = TBL_CITA_DETALLE.id_cita
                                  WHERE numero_doc_cliente = '"+ dni_paciente + "' and codigo_especialidad = '"+ codigo_especialidad + "' and hora = '"+ hora + "' and fecha_cita = '"+ fecha_cita + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
