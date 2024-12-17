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
   public class DatosTurno
    {
        public static List<EntidadTurno> ListTurnos(string fecha, int cod_especialidad)
        {
            List<EntidadTurno> lst = new List<EntidadTurno>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                //string query = @"select hora,isnull(dni_paciente, '') as paciente,nombres+' '+apellidos as doctor,ISNULL(descripcion_principal,'') AS descripcion_principal,ISNULL(precio,0) as precio,TBL_TURNO.estado as estadoTurno,codigo_item,id_turno from 
                //               TBL_CATALOGO right join(TBL_EMPLEADO inner join TBL_TURNO on TBL_EMPLEADO.dni_empleado = TBL_TURNO.dni_empleado) on TBL_CATALOGO.codigo_item_catalogo = TBL_TURNO.codigo_item where fecha = '" + fecha + "' and codigo_especialidad = '" + cod_especialidad + "' order by hora";

                string query = @"select hora,isnull(dni_paciente, '') as paciente,nombres+' '+apellidos as doctor,TBL_TURNOS_CONSULTORIO.estado as estadoTurno,id_turno_consultorio from 
                                 TBL_EMPLEADO inner join TBL_TURNOS_CONSULTORIO on TBL_EMPLEADO.dni_empleado = TBL_TURNOS_CONSULTORIO.dni_empleado where fecha = '" + fecha + "' and codigo_especialidad = '" + cod_especialidad + "' order by hora";


                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadTurno enttur = new EntidadTurno()
                            {
                                hora = dr["hora"].ToString(),
                                dni_paciente = dr["paciente"].ToString(),
                                dni_empleado = dr["doctor"].ToString(),
                               // descripcion_item = dr["descripcion_principal"].ToString(),
                                //precio_item = Convert.ToDecimal(dr["precio"]),
                                estado = dr["estadoTurno"].ToString(),
                                //cod_item_catalogo = dr["codigo_item"].ToString(),
                                id_turno = Convert.ToInt32(dr["id_turno_consultorio"])

                            };
                            lst.Add(enttur);
                        }
                    }                       

                }
            }

                return lst;
        }
        public static void InsertTurno(EntidadTurno entTurno)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_TURNOS_CONSULTORIO(hora,id_turno_consultorio,dni_empleado,codigo_persona_pago,dni_paciente,codigo_item,codigo_especialidad,estado,fecha) VALUES('" + entTurno.hora+"', '"+entTurno.id_turno+"', '"+entTurno.dni_empleado+"', '"+entTurno.cod_persona_pago+"', '"+entTurno.dni_paciente+"', '"+entTurno.cod_item_catalogo+"', '"+entTurno.cod_especialidad+"', '"+entTurno.estado+"', '"+entTurno.fecha+"')";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }
        
        public static void UpdateTurno(EntidadTurno entTurno)
        {

        }
        public static void DeleteTurno(EntidadTurno entTurno)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "DELETE FROM TBL_TURNOS_CONSULTORIO WHERE hora='" + entTurno.hora+ "' AND id_turno_consultorio='" + entTurno.id_turno+"' AND codigo_especialidad='"+entTurno.cod_especialidad+"' AND fecha='"+entTurno.fecha+"'  ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void OcuparTurno(string dni_paciente,string hora, string fechaocupar,int cod_especialidad,string cod_item_catalogo)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "UPDATE TBL_TURNOS_CONSULTORIO SET dni_paciente='"+ dni_paciente + "',codigo_item='"+ cod_item_catalogo + "',estado='Ocupado' WHERE hora='" + hora + "' AND fecha='"+ fechaocupar + "' AND codigo_especialidad='"+ cod_especialidad + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DesocuparTurno(int id_regTurno, string hora, int codigo_especialidad)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "UPDATE TBL_TURNOS_CONSULTORIO SET dni_paciente='',codigo_item='',estado='Disponible' WHERE id_turno_consultorio='" + id_regTurno + "' and hora='"+hora+"' and codigo_especialidad='"+codigo_especialidad+"'  ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
