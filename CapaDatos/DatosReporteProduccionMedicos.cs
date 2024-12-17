using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

using CapaEntidad;

namespace CapaDatos
{
   public  class DatosReporteProduccionMedicos
    {
        public static List<EntidadReporteProduccionMedicos> ListarReportexDNI(string dni_empleado)
        {
            List<EntidadReporteProduccionMedicos> objList = new List<EntidadReporteProduccionMedicos>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                con.Open();
                string strSProcedure = "spReporteProduccionMedicos";
                using (SqlCommand cmd = new SqlCommand(strSProcedure, con))
                {
                    cmd.CommandText = strSProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@dni_empleado", SqlDbType.Char,8)).Value = dni_empleado;

                   SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EntidadReporteProduccionMedicos objentidad = new EntidadReporteProduccionMedicos()
                        {
                            num_doc_cliente = dr["numero_doc_cliente"].ToString(),
                            apellido_paterno = dr["apellido_paterno"].ToString(),
                            apellido_materno = dr["apellido_materno"].ToString(),
                            nombres = dr["nombres"].ToString(),
                            fecha_atencion = dr["fecha_atencion"].ToString(),
                            hora_atencion = dr["hora_atencion"].ToString(),
                            descripcion_servicio = dr["descripcion_item"].ToString(),
                            monto_pagar = dr["pago"].ToString()

                        };
                        objList.Add(objentidad);
                    }

                }

            }
            return objList;
        }
    }
}
