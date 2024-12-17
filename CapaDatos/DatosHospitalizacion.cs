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
   public class DatosHospitalizacion
    {
        public static List<EntidadHospitalizacion> ListHospitalizacion()
        {
            List<EntidadHospitalizacion> lst = new List<EntidadHospitalizacion>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select id_registro_hospitalizacion,numero_historia_clinica,numero_doc_cliente,codigo_persona,tipo_movimiento,fecha_ingreso_egreso,hora_ingreso_egreso,origen_ingreso_egreso,id_cama,id_piso,edad,recien_nacido,medico_autoriza_ingreso_egreso,servicio_ingresa_egresa,cod_cie_diez,id_reg_acompanante,destino_egreso,tipo_alta,condicion_alta,numero_admision from TBL_HOSPITALIZACION ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadHospitalizacion entHospi = new EntidadHospitalizacion()
                            {
                                id_registro_hospitalizacion = Convert.ToInt32(dr["id_registro_hospitalizacion"]),
                                numero_historia_clinica = dr["numero_historia_clinica"].ToString(),
                                numero_doc_cliente =  dr["numero_doc_cliente"].ToString(),
                                codigo_persona = Convert.ToInt32(dr["codigo_persona"]),
                                id_cama = Convert.ToInt32(dr["id_cama"]),
                                fecha_ingreso_egreso = dr["fecha_ingreso_egreso"].ToString(),
                                hora_ingreso_egreso = dr["hora_ingreso_egreso"].ToString(),
                                cod_cie_diez = dr["cod_cie_diez"].ToString(),
                                condicion_alta= dr["condicion_alta"].ToString(),  
                                numero_admision = Convert.ToInt32(dr["numero_admision"])
                                                             
                            };
                            lst.Add(entHospi);
                        }
                    }

                }

            }
            return lst;
        }
        public static void InsertHospitalizacion(EntidadHospitalizacion entHosp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_HOSPITALIZACION(id_registro_hospitalizacion,numero_historia_clinica,numero_doc_cliente,codigo_persona,tipo_movimiento,fecha_ingreso_egreso,hora_ingreso_egreso,origen_ingreso_egreso,id_cama,id_piso,edad,recien_nacido,medico_autoriza_ingreso_egreso,servicio_ingresa_egresa,cod_cie_diez,id_reg_acompanante,destino_egreso,tipo_alta,condicion_alta,numero_admision) VALUES((SELECT ISNULL(MAX(id_registro_hospitalizacion),0)+1 FROM TBL_HOSPITALIZACION),'" + entHosp.numero_historia_clinica+ "','" + entHosp.numero_doc_cliente + "','" + entHosp.codigo_persona+ "' ,'" + entHosp.tipo_movimiento + "' ,'" + entHosp.fecha_ingreso_egreso + "' ,'" + entHosp.hora_ingreso_egreso + "' ,'" + entHosp.origen_ingreso_egreso + "' ,'" + entHosp.id_cama + "' ,'" + entHosp.id_piso + "' ,'" + entHosp.edad + "' ,'" + entHosp.recien_nacido + "' ,'" + entHosp.medico_autoriza_ingreso_egreso + "' ,'" + entHosp.servicio_ingresa_egresa + "' ,'" + entHosp.cod_cie_diez + "','" + entHosp.id_reg_acompanante + "','" + entHosp.destino_egreso + "','" + entHosp.tipo_alta + "','" + entHosp.condicion_alta + "','" + entHosp.numero_admision + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
