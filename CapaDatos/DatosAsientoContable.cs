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
   public class DatosAsientoContable
    {
        public static List<EntidadAsientoContable> ListAsientosContables(int periodo_anio,string num_doc_cliente)
        {
            List<EntidadAsientoContable> lst = new List<EntidadAsientoContable>();
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
                            EntidadAsientoContable entAsiento = new EntidadAsientoContable()
                            {
                                id_regAsiento = Convert.ToInt32(dr[""]),
                                fecha_operacion = dr[""].ToString(),
                                descrip_operacion = dr[""].ToString(),
                                num_doc_contable = dr[""].ToString(),
                                debe = dr[""].ToString(),
                                haber = dr[""].ToString(),
                                redondeo = Convert.ToDecimal(dr[""]),
                                id_regPlancontable = Convert.ToInt32(dr[""]),
                                periodo_anio = Convert.ToInt32(dr[""]),
                                periodo_mes = dr[""].ToString(),
                                num_doc_cliente = dr[""].ToString(),
                                nombre_cliente = dr[""].ToString()

                            };
                            lst.Add(entAsiento);
                        }

                    }
                }
            }
                return lst;
        }
        public static void InsertAsientoContable(string tipo_doc,string numero_doc)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "spGenerarAsientoContable";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@tipo_doc_contable", System.Data.SqlDbType.Char,2)).Value = tipo_doc;
                    cmd.Parameters.Add(new SqlParameter("@num_doc_contable", System.Data.SqlDbType.VarChar, 20)).Value = numero_doc;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
