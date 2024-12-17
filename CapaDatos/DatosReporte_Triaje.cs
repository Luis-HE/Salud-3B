using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using CapaEntidad;

namespace CapaDatos
{
   public class DatosReporte_Triaje
    {
        public static List<EntidadReporte_Triaje> ListarRepporteTriaje(string fecha1, string fecha2)
        {
            List<EntidadReporte_Triaje> objList = new List<EntidadReporte_Triaje>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                con.Open();
                string strSProcedure = "spReporteTriaje";
                using (SqlCommand cmd = new SqlCommand(strSProcedure, con))
                {
                    cmd.CommandText = strSProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fecha1", SqlDbType.VarChar, 16)).Value = fecha1;
                    cmd.Parameters.Add(new SqlParameter("@fecha2", SqlDbType.VarChar, 16)).Value = fecha2;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EntidadReporte_Triaje objentidad = new EntidadReporte_Triaje()
                        {
                            col1 = dr["col1"].ToString(),
                            col2 = dr["col2"].ToString(),
                            col3 = dr["col3"].ToString(),
                            col4 = dr["col4"].ToString(),
                            col5 = dr["col5"].ToString()

                        };
                        objList.Add(objentidad);
                    }

                }

            }
            return objList;
        }
    }
}
