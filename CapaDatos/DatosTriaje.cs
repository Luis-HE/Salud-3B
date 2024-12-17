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
   public class DatosTriaje
    {
        public static List<EntidadTriaje> ListarTriaje()
        {
            List<EntidadTriaje> lst = new List<EntidadTriaje>();

            return lst;
        }
        public static void InsertarTriaje(EntidadTriaje entTriaje)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_TRIAJE(id_registro_triaje,numero_admision,numero_historia_clinica,numero_doc_cliente,codigo_persona,talla,edad,peso,presion_arterial_sistolica,temperatura,prioridad,frecuencia_cardiaca,indice_masa_cuerpo,frecuencia_respiratoria,num_doc_pago,serie_doc_pago,tipo_doc_pago,fecha_atencion,sp_oxigeno,gineco_problema_principal,gineco_tiempo_embarazo,gineco_diabetes_mellitus,gineco_hipertension_arterial,gineco_cardiopatia,gineco_enf_tiroidea,gineco_enf_renal,gineco_otras_patologias,gineco_amenaza_aborto,gineco_amenaza_parto,gineco_embarazo_termino,gineco_enf_hipertensiva,gineco_hemorragia,gineco_sepsis,gineco_otros_problemas,gineco_sintomatologia,gineco_indice_choque,gineco_diagnostico_probable,gineco_plan_terapeutico,hora_atencion,dni_empleado,codigo_persona_pago,presion_arterial_diastolica ) VALUES('" + entTriaje.id_registro_triaje+ "', '" + entTriaje.numero_admision + "','" + entTriaje.num_hist_clinica + "','" + entTriaje.num_doc_cliente + "', '" + entTriaje.cod_persona + "', '" + entTriaje.talla + "','" + entTriaje.edad + "','" + entTriaje.peso + "','" + entTriaje.presion_arterial_sistolica + "','" + entTriaje.temperatura + "','" + entTriaje.prioridad + "','" + entTriaje.frecuencia_cardiaca + "','" + entTriaje.indice_masa_corporal + "','" + entTriaje.frecuencia_respiratoria + "','" + entTriaje.num_doc_pago + "','" + entTriaje.serie_doc_pago + "','" + entTriaje.tipo_doc_pago + "','" + entTriaje.fecha_atencion + "','" + entTriaje.sp_oxigeno + "','" + entTriaje.gineco_problema_principal + "','" + entTriaje.gineco_tiempo_embarazo + "', '" + entTriaje.gineco_diabetes_mellitus + "', '" + entTriaje.gineco_hipertension_arterial + "', '" + entTriaje.gineco_cardiopatia + "', '" + entTriaje.gineco_enf_tiroidea + "', '" + entTriaje.gineco_enf_renal + "','" + entTriaje.gineco_otras_patologias + "', '" + entTriaje.gineco_amenaza_aborto + "', '" + entTriaje.gineco_amenaza_parto + "', '" + entTriaje.gineco_embarazo_termino + "', '" + entTriaje.gineco_enf_hipertensiva + "', '" + entTriaje.gineco_hemorragia + "','" + entTriaje.gineco_sepsis + "', '" + entTriaje.gineco_otros_problemas + "','" + entTriaje.gineco_sintomatologia + "', '" + entTriaje.gineco_indice_choque + "','" + entTriaje.gineco_diagnostico_probable + "', '" + entTriaje.gineco_plan_terapeutico + "','" + entTriaje.hora_atencion + "','" + entTriaje.dni_empleado + "','" + entTriaje.codigo_persona_pago + "','"+entTriaje.presion_arterial_diastolica +"' ) ";
                con.Open(); 
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public static List<EntidadTriaje> ColaTriaje(int day, int month, int year)
        {
            List<EntidadTriaje> lst = new List<EntidadTriaje>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
               string query = "select TBL_ADMISION.numero_admision,tipo_admision, TBL_CLIENTE_PERSONA.numero_doc_cliente,apellido_paterno,apellido_materno,fecha_nace,monto_adelanto,total,tipo_documento,serie,numero_documento from ((TBL_CLIENTE_PERSONA inner join TBL_ADMISION on TBL_CLIENTE_PERSONA.numero_doc_cliente=TBL_ADMISION.numero_doc_cliente) INNER JOIN TBL_DOCUMENTO_CONTABLE ON TBL_ADMISION.numero_admision= TBL_DOCUMENTO_CONTABLE.numero_admision) LEFT JOIN TBL_TRIAJE ON TBL_ADMISION.numero_admision = TBL_TRIAJE.numero_admision where TBL_TRIAJE.numero_admision IS NULL AND tipo_admision<>'Emergencia' AND day(fecha_admision)='" + day+"' and MONTH(fecha_admision)='"+month+"' and YEAR(fecha_admision)='"+year+"' ";


                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadTriaje entTriaje = new EntidadTriaje()
                            {
                                numero_admision = Convert.ToInt32(dr["numero_admision"]),
                                tipo_admision = dr["tipo_admision"].ToString(),
                                numdoc = dr["numero_doc_cliente"].ToString(),
                                apelPater = dr["apellido_paterno"].ToString(),
                                apelMater = dr["apellido_materno"].ToString(),
                                fecha_nace = dr["fecha_nace"].ToString(),
                                mont_adelanto = Convert.ToDecimal(dr["monto_adelanto"]),
                                monto_total = Convert.ToDecimal(dr["total"]),
                                tipo_doc_pago = dr["tipo_documento"].ToString(),
                                serie_doc_pago = dr["serie"].ToString(),
                                num_doc_pago =  dr["numero_documento"].ToString()

                            };
                            lst.Add(entTriaje);
                        }
                    }

                }
            }
            return lst;
        }
    }
}
