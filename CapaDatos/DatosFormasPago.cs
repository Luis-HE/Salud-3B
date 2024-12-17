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
   public class DatosFormasPago
    {
        public static List<EntidadFormasPago> ListFormasPago(string fecha_pago,string tipo_doc,string serie, string num_doc_contable,int id_unidad_negocio)
        {
            List<EntidadFormasPago> lst = new List<EntidadFormasPago>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "select id_reg_formapago,fecha_pago,monto_pago,forma_de_pago,tipo_moneda,numero_documento,serie,tipo_documento,id_unidad_negocio from TBL_FORMAS_PAGO WHERE CONVERT(varchar(10),fecha_pago,103)='"+fecha_pago+"' and tipo_documento='"+tipo_doc+"' and serie='"+serie+"' and numero_documento='"+num_doc_contable+ "' and id_unidad_negocio='"+id_unidad_negocio+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadFormasPago entForP= new EntidadFormasPago()
                            {
                                id_reg_formapago = Convert.ToInt32(dr["id_reg_formapago"]),
                                fecha_pago = dr["fecha_pago"].ToString(),
                                monto_pago = Convert.ToDecimal(dr["monto_pago"]),
                                forma_de_pago = dr["forma_de_pago"].ToString(),
                                tipo_moneda = dr["tipo_moneda"].ToString(),
                                numero_documento = dr["numero_documento"].ToString(),
                                serie = dr["serie"].ToString(),
                                tipo_documento = dr["tipo_documento"].ToString()
                            };
                            lst.Add(entForP);
                        }
                    }

                }
            }
            return lst;
        }
        public static void InsertFormasPago(EntidadFormasPago entForp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "INSERT INTO TBL_FORMAS_PAGO(id_reg_formapago,fecha_pago,monto_pago,forma_de_pago,tipo_moneda,numero_documento,serie,tipo_documento,id_unidad_negocio) VALUES((SELECT ISNULL(MAX(id_reg_formapago),0)+1 FROM TBL_FORMAS_PAGO),'" + entForp.fecha_pago+"','"+entForp.monto_pago+"','"+entForp.forma_de_pago+"','"+entForp.tipo_moneda+"','"+entForp.numero_documento+"','"+entForp.serie+"','"+entForp.tipo_documento+"','"+entForp.id_unidad_negocio+"')";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateFormasPago(EntidadFormasPago entForp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteFormasPago(int id_reg_forma_pago)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "DELETE FROM TBL_FORMAS_PAGO WHERE id_reg_formapago='"+ id_reg_forma_pago + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
