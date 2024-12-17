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
   public class DatosProgramadorTurnos
    {
        public static List<EntidadProgramadorTurnos> ListProgramadorTurnos(EntidadProgramadorTurnos entprogT)
        {
            List<EntidadProgramadorTurnos> lst = new List<EntidadProgramadorTurnos>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "SELECT id_registro,hora,'"+ entprogT.id_turno + "' as IdTurno,'" + entprogT.dni_empleado + "' as DniEmpleado,'" + entprogT.cod_persona + "' as codPersona,'" + entprogT.dni_paciente + "' as DniPacie,'" + entprogT.id_item + "' as IdItem,'" + entprogT.cod_especialidad + "' as Codespecialida,'" + entprogT.estado + "' as estado,'" + entprogT.fecha + "' as fecha FROM TBL_PROGRAMADOR_TURNO";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadProgramadorTurnos antProgTurno = new EntidadProgramadorTurnos()
                            {
                                id_registro = Convert.ToInt32(dr["id_registro"]),
                                hora = dr["hora"].ToString(),
                                id_turno = Convert.ToInt32(dr["IdTurno"]),
                                dni_empleado = dr["DniEmpleado"].ToString(),
                                cod_persona = Convert.ToInt32(dr["codPersona"]),
                                dni_paciente = dr["DniPacie"].ToString(),
                                id_item = dr["IdItem"].ToString(),
                                cod_especialidad = Convert.ToInt32(dr["Codespecialida"]),
                                estado = dr["estado"].ToString(),
                                fecha = dr["fecha"].ToString()

                            };
                            lst.Add(antProgTurno);
                        }
                    }
                }

            }
            return lst;
        }
    }
}
