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
   public class DatosLibroMayor
    {
        public static List<EntidadLibroMayor> ListLibroMayor(int periodo_anio,string periodo_mes,string num_doc_cliente)
        {
            List<EntidadLibroMayor> lst = new List<EntidadLibroMayor>();
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
                            EntidadLibroMayor entLibro = new EntidadLibroMayor()
                            {
                                id_regLibro = Convert.ToInt32(dr[""]),
                                periodo_mes = dr[""].ToString(),
                                periodo_anio = Convert.ToInt32(dr[""]),
                                nombre_cliente = dr[""].ToString(),
                                numero_asiento = Convert.ToInt32(dr[""]),
                                fecha = dr[""].ToString(),
                                definicion = dr[""].ToString(),
                                cod_cuenta = dr[""].ToString(),
                                descripcion_desglose = dr[""].ToString(),
                                debe = dr[""].ToString(),
                                haber = dr[""].ToString()
                            };
                            lst.Add(entLibro);
                        }
                    }
                }

            }
                return lst;
        }
        public static void InsertLibroMayor(string tipo_doc, string numero_doc)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "spRegistarLibroMayor";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@tipo_doc_contable", System.Data.SqlDbType.Char, 2)).Value = tipo_doc;
                    cmd.Parameters.Add(new SqlParameter("@num_doc_contable", System.Data.SqlDbType.VarChar, 20)).Value = numero_doc;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
