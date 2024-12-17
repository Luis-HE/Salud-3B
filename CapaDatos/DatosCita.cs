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
   public class DatosCita
    {
        public static List<EntidadCita> ListCitas(string dni_paciente)
        {
            List<EntidadCita> lst = new List<EntidadCita>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "select id_cita,fecha_registro,numero_doc_cliente,id_cia_seguro,tipo_paciente,codigo_persona,fecha_cita,observacion,nombre_usuario from TBL_CITA where numero_doc_cliente='" +dni_paciente+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                { 
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadCita entCita = new EntidadCita()
                            {
                                id_cita = Convert.ToInt32(dr["id_cita"]),
                                fecha_registro = dr["fecha_registro"].ToString(),
                                num_doc_cliente = dr["numero_doc_cliente"].ToString(),
                                id_cia_seguro = Convert.ToInt32( dr["id_cia_seguro"]),
                                tipo_paciente = dr["tipo_paciente"].ToString(),
                                cod_persona = Convert.ToInt32( dr["codigo_persona"]),
                                fecha_cita = dr["fecha_cita"].ToString(),
                                observacion = dr["observacion"].ToString(),
                                nombre_usuario = dr["nombre_usuario"].ToString()
                                
                            };
                            lst.Add(entCita);
                        }
                    }

                }
            }
            return lst;
        }
        public static void InsertCita(EntidadCita entcita)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "INSERT INTO TBL_CITA(id_cita,fecha_registro,numero_doc_cliente,id_cia_seguro,tipo_paciente,codigo_persona,fecha_cita,observacion,nombre_usuario) VALUES((SELECT ISNULL(MAX(id_cita),0)+1 FROM tbl_cita), '" + entcita.fecha_registro+"','"+entcita.num_doc_cliente+"','"+entcita.id_cia_seguro+"','"+entcita.tipo_paciente+"','"+entcita.cod_persona+"','"+entcita.fecha_cita+"','"+entcita.observacion+ "','" + entcita.nombre_usuario + "') ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {  
                    cmd.ExecuteNonQuery();                  
                }
            }
        }
        public static void UpdateCita()
        {

        }
        public static void DeleteCita()
        {

        }
        public static List<EntidadCita> GetLastIdRegCita(string dni_cliente,string fecha_cita,int anio,int mes,int dia)
        {
            List<EntidadCita> lst = new List<EntidadCita>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "select max(id_cita) AS numero_cita from TBL_CITA  where numero_doc_cliente = '" + dni_cliente + "' and fecha_cita = '"+ fecha_cita + "' and YEAR(CONVERT(date, fecha_registro,103)) = '" + anio + "' AND Month(CONVERT(date, fecha_registro,103)) = '" + mes + "' AND DAY(CONVERT(date, fecha_registro,103)) = '" + dia + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadCita entCita = new EntidadCita()
                            {
                                id_cita = Convert.ToInt32(dr["numero_cita"])
                            };
                            lst.Add(entCita);
                        }
                    }

                }
            }
            return lst;
        }
    }
}
