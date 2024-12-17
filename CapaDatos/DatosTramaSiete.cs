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
   public class DatosTramaSiete
    {
        public static List<EntidadTramaSiete> ListTramaSiete(int mes, int numero_tabla)
        {
            List<EntidadTramaSiete> lst = new List<EntidadTramaSiete>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "SELECT cast(YEAR(fecha_emision) as CHAR(4)) + '' + cast(month(fecha_emision) as CHAR(2)) + '' + cast(DAY(fecha_emision) as CHAR(2)) AS col1,cast(DATEPART(HOUR, fecha_emision) as CHAR(2))+'' +RIGHT('00'+cast(DATEPART(MINUTE, fecha_emision) as varCHAR(2)),2)  + '' + cast(DATEPART(SECOND, fecha_emision) as CHAR(2)) as col2,tipo_documento as col3,numero_documento as col4,'20552144415' as col5,'CODIPRESS' as col6,'00'as col7,'00' as col8, '00' as col9 FROM TBL_DOC_CONTABLE WHERE MONTH(fecha_emision)='"+mes+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadTramaSiete entTramasiete = new EntidadTramaSiete()
                            {
                                colUno = dr["col1"].ToString(),
                                colDos = dr["col2"].ToString(),
                                colTres = dr["col3"].ToString(),
                                colCuatro = dr["col4"].ToString(),
                                colCinco = dr["col5"].ToString(),
                                colSeis = dr["col6"].ToString(),
                                colSiete = dr["col7"].ToString(),
                                colOcho = dr["col8"].ToString(),
                                colNueve = dr["col9"].ToString()
                            };
                            lst.Add(entTramasiete);
                        }
                    }

                }
            }
            return lst;
        }
    }
}
