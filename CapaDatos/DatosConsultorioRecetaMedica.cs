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
   public  class DatosConsultorioRecetaMedica
    {
        public static void InsertarRecetaMedica(EntidadConsultorioRecetaMedica entReceta)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "INSERT INTO TBL_CONSULTORIO_RECETA_MEDICA(id_receta,fecha_hasta_vigencia,dni_empleado,codigo_persona_pago,numero_admision,numero_doc_cliente,codigo_persona,alergico,indicaciones,fecha_receta) VALUES( (SELECT ISNULL(MAX(id_receta),0)+1 FROM TBL_CONSULTORIO_RECETA_MEDICA) ,'" + entReceta.fecha_hasta_vigencia + "','" + entReceta.dni_empleado + "' ,'" + entReceta.cod_persona_pago + "','" + entReceta.num_admision + "','" + entReceta.num_doc_cliente + "','" + entReceta.cod_persona + "','" + entReceta.alergico + "','" + entReceta.indicaciones + "','" + entReceta.fecha_receta + "' ) ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<EntidadConsultorioRecetaMedica> GetLastIdRegReceta(string dni_cliente, int anio, int mes, int dia)
        {
            List<EntidadConsultorioRecetaMedica> lst = new List<EntidadConsultorioRecetaMedica>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select max(id_receta) AS num_receta from TBL_CONSULTORIO_RECETA_MEDICA where numero_doc_cliente ='" + dni_cliente + "' and YEAR(convert(date,fecha_receta,103))='" + anio + "' and MONTH(convert(date,fecha_receta,103))='" + mes + "' and DAY(convert(date,fecha_receta,103))='" + dia + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadConsultorioRecetaMedica entAdm = new EntidadConsultorioRecetaMedica()
                            {
                                id_receta = Convert.ToInt32(dr["num_receta"])
                            };
                            lst.Add(entAdm);

                        }
                    }
                }

            }
            return lst;
        }
    }
}
