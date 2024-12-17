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
   public class DatosLaboratorio
    {
        public static void InsertarLaboratorio(EntidadLaboratorio ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_LABORATORIO(id_reg_laboratorio,numero_admision,fecha_muestra,num_informe_lab,diagnostico,dni_empleado,codigo_persona_pago,edad,numero_historia_clinica,numero_doc_cliente,codigo_persona,hora_muestra) VALUES( (SELECT ISNULL(MAX(id_reg_laboratorio),0)+1 FROM TBL_LABORATORIO) ,'" + ent.numero_admision + "','" + ent.fecha_muestra + "','" + ent.num_informe_lab + "','" + ent.diagnostico + "','" + ent.dni_empleado + "' , '" + ent.codigo_persona_pago + "','" + ent.edad + "','" + ent.num_historia_clinica + "','" + ent.num_doc_cliente + "','" + ent.codigo_persona + "','" + ent.hora_muestra + "' ) ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<EntidadLaboratorio> GetLastIdRegLaboratorio(string dni_cliente, int anio, int mes, int dia)
        {
            List<EntidadLaboratorio> lst = new List<EntidadLaboratorio>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select max(id_reg_laboratorio) AS idLab from TBL_LABORATORIO where numero_doc_cliente ='" + dni_cliente + "'  and YEAR(convert(date,fecha_muestra,103))='" + anio + "' and MONTH(convert(date,fecha_muestra,103))='" + mes + "' and DAY(convert(date,fecha_muestra,103))='" + dia + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadLaboratorio entAdm = new EntidadLaboratorio()
                            {
                                id_reg_laboratorio = Convert.ToInt32(dr["idLab"])
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
