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
   public class DatosAdmision
    {
        public static List<EntidadAdmision> ListAdmision()
        {
            List<EntidadAdmision> lst = new List<EntidadAdmision>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            EntidadAdmision entAdm = new EntidadAdmision()
                            {

                            };
                            lst.Add(entAdm);
                            
                        }
                    }
                } 

            }
                return lst;
        }
        public static void InsertAdmision(EntidadAdmision entAdm)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_ADMISION(numero_admision,fecha_admision,nombre_usuario,observacion,monto_adelanto,cobertura,tipo_admision,tipo_paciente,id_cia_seguro,numero_doc_cliente,id_cita,paciente_vip,codigo_persona,codigo_carta_garantia,nombre_garante,id_reg_acompanante) VALUES((SELECT ISNULL(MAX(numero_admision),0)+1 FROM TBL_ADMISION),'" + entAdm.fecha_admision + "','" + entAdm.nombre_usuario + "','" + entAdm.observacion + "','" + entAdm.monto_adelanto + "','" + entAdm.cobertura + "','" + entAdm.tipo_admision + "','" + entAdm.tipo_paciente + "','" + entAdm.id_cia_seguro + "','" + entAdm.numero_doc_cliente + "','"+entAdm.id_cita+"','" + entAdm.paciente_vip + "','" + entAdm.codigo_persona + "','" + entAdm.cod_carta_garantia + "','" + entAdm.nomb_garante + "','"+entAdm.id_reg_acompanante+"' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static void InsertAdmisionAmbulatoria(EntidadAdmision entAdm)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_ADMISION(numero_admision,fecha_admision,nombre_usuario,observacion,monto_adelanto,cobertura,tipo_admision,tipo_paciente,id_cia_seguro,numero_doc_cliente,paciente_vip,codigo_persona,codigo_carta_garantia,nombre_garante,id_reg_acompanante) VALUES((SELECT ISNULL(MAX(numero_admision),0)+1 FROM TBL_ADMISION),'" + entAdm.fecha_admision + "','" + entAdm.nombre_usuario + "','" + entAdm.observacion + "','" + entAdm.monto_adelanto + "','" + entAdm.cobertura + "','" + entAdm.tipo_admision + "','" + entAdm.tipo_paciente + "','" + entAdm.id_cia_seguro + "','" + entAdm.numero_doc_cliente + "','" + entAdm.paciente_vip + "','" + entAdm.codigo_persona + "','" + entAdm.cod_carta_garantia + "','" + entAdm.nomb_garante + "','" + entAdm.id_reg_acompanante + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<EntidadAdmision> GetLastIdRegAtencion( string dni_cliente,int cod_cia_seguro ,int anio, int mes, int dia)
        {
            List<EntidadAdmision> lst = new List<EntidadAdmision>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select max(numero_admision) AS num_admision from TBL_ADMISION where numero_doc_cliente ='" + dni_cliente + "' and id_cia_seguro='"+ cod_cia_seguro + "' and YEAR(convert(date,fecha_admision,103))='" + anio + "' and MONTH(convert(date,fecha_admision,103))='" + mes+ "' and DAY(convert(date,fecha_admision,103))='" + dia + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadAdmision entAdm = new EntidadAdmision()
                            {
                                numero_admision = Convert.ToInt32(dr["num_admision"])
                            };
                            lst.Add(entAdm);

                        }
                    }
                }

            }
            return lst;
        }
        public static void UpdateEstadoAdmision(int numero_admision)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = " update TBL_ADMISION_DETALLE set estado='Atendido' where numero_admision='"+ numero_admision + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
