using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using CapaEntidad;

namespace CapaDatos
{
   public class DatosReporte_Admision
    {
        public static List<EntidadReporte_Admision> ListarReporteAdmision(string fecha1, string fecha2)
        {
            List<EntidadReporte_Admision> objList = new List<EntidadReporte_Admision>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                con.Open();
                string strSProcedure = "spReporteAdmision";
                using (SqlCommand cmd = new SqlCommand(strSProcedure, con))
                {
                    cmd.CommandText = strSProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fecha1", SqlDbType.VarChar, 16)).Value = fecha1;
                    cmd.Parameters.Add(new SqlParameter("@fecha2", SqlDbType.VarChar, 16)).Value = fecha2;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EntidadReporte_Admision objentidad = new EntidadReporte_Admision()
                        {
                            col1 = dr["col1"].ToString(),
                            col2 = dr["col2"].ToString(),
                            col3 = dr["col3"].ToString(),
                            col4 = dr["col4"].ToString(),
                            col5 = dr["col5"].ToString(),
                            col6 = dr["col6"].ToString(),
                            col7 = dr["col7"].ToString(),
                            col8 = dr["col8"].ToString()

                        };
                        objList.Add(objentidad);
                    }

                }

            }
            return objList;
        }
    }
}
