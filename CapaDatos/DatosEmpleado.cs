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
   public class DatosEmpleado
    {
        public static List<EntidadEmpleado> ListEmpleados()
        {
            List<EntidadEmpleado> lst = new List<EntidadEmpleado>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select dni_empleado,apellidos , nombres,codigo_area,telefono,celular,email,codigo_persona_pago,numero_cuenta,nombre_banco,porcentaje_comision,numero_ruc,tipo_contrato from TBL_EMPLEADO ORDER BY apellidos ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadEmpleado entEmp = new EntidadEmpleado()
                            {
                                dni_empleado = dr["dni_empleado"].ToString(),
                                apellidos = dr["apellidos"].ToString(),
                                nombres = dr["nombres"].ToString(),
                                cod_area = Convert.ToInt32(dr["codigo_area"].ToString()),
                                telefono = dr["telefono"].ToString(),
                                celular = dr["celular"].ToString(),
                                email = dr["email"].ToString(),
                                cod_personaPago = Convert.ToInt32(dr["codigo_persona_pago"]),
                                num_cuenta = dr["numero_cuenta"].ToString(),
                                nombre_banco = dr["nombre_banco"].ToString(),
                                porcentaje_comision = Convert.ToDecimal(dr["porcentaje_comision"].ToString()),
                                num_ruc = dr["numero_ruc"].ToString(),
                                tipo_contrato = dr["tipo_contrato"].ToString()                              
                            };
                            lst.Add(entEmp);
                        }
                    }
                }

            }
            return lst;

        }
        public static void InsertEmpleado(EntidadEmpleado entEmp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_EMPLEADO(dni_empleado,apellidos , nombres,codigo_area,telefono,celular,email,codigo_persona_pago,numero_cuenta,nombre_banco,porcentaje_comision,numero_ruc,tipo_contrato) VALUES('"+entEmp.dni_empleado+ "','" + entEmp.dni_empleado + "')";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateEmpleado(EntidadEmpleado entEmp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "UPDATE TBL_EMPLEADO  SET  apellidos='"+entEmp.apellidos+"' , nombres='"+entEmp.nombres+"',telefono='"+entEmp.telefono+"',celular='"+entEmp.celular+"',email='"+entEmp.email+"' WHERE dni_empleado ='"+entEmp.dni_empleado+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteEmpleado(EntidadEmpleado entEmp)
        {

        }
        public static List<EntidadEmpleado> ListEmpleados(int Id_area)
        {
            List<EntidadEmpleado> lst = new List<EntidadEmpleado>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select dni_empleado,codigo_persona_pago, apellidos , nombres  from TBL_EMPLEADO where codigo_area='"+Id_area+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            EntidadEmpleado entEmp = new EntidadEmpleado()
                            {
                                dni_empleado =dr["dni_empleado"].ToString(),
                                cod_personaPago = Convert.ToInt32( dr["codigo_persona_pago"]) ,
                                apellidos =dr["apellidos"].ToString(),
                                nombres =dr["nombres"].ToString()

                            };
                            lst.Add(entEmp);
                        }
                    }
                }

            }
                return lst;

        }
    }
}
