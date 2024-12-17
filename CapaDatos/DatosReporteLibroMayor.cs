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
   public class DatosReporteLibroMayor
    {
        public static List<EntidadReporteLibroMayor> ListReporteLibroMayorCabecera(string periodo_mes, int periodo_anio, string num_docCliente)
        {
            List<EntidadReporteLibroMayor> lst = new List<EntidadReporteLibroMayor>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select cod_cuenta,descripcion_desglose from TBL_LIBRO_MAYOR where periodo_anio='"+periodo_anio+"' and periodo_mes='"+periodo_mes+"' group by cod_cuenta,descripcion_desglose";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadReporteLibroMayor entAsiento = new EntidadReporteLibroMayor()
                            {
                                cuenta_contable = dr["cod_cuenta"].ToString(),
                                descripcion_cuenta = dr["descripcion_desglose"].ToString()                                
                            };
                            lst.Add(entAsiento);
                        }

                    }
                }
            }
            return lst;
        }
        public static List<EntidadReporteLibroMayor> ListReporteLibroMayorDetalle(string periodo_mes, int periodo_anio, string cod_cuenta)
        {
            List<EntidadReporteLibroMayor> lst = new List<EntidadReporteLibroMayor>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select convert(varchar(10), fecha,103) as fecha, cod_cuenta,descripcion_desglose,debe,haber from TBL_LIBRO_MAYOR  where cod_cuenta='"+ cod_cuenta + "'";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadReporteLibroMayor entAsiento = new EntidadReporteLibroMayor()
                            {
                                fecha = dr["fecha"].ToString(),
                                cuenta_contable = dr["cod_cuenta"].ToString(),
                                descripcion_cuenta = dr["descripcion_desglose"].ToString(),
                                debe = dr["debe"].ToString(),
                                haber = dr["haber"].ToString()
                            };
                            lst.Add(entAsiento);
                        }

                    }
                }
            }
            return lst;
        }
    }
}
