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
  public  class DatosClienteEmpresa
    {
        public static List<EntidadClienteEmpresa> ListClienteEmpresa(string ruc_cliente)
        {
            List<EntidadClienteEmpresa> lst = new List<EntidadClienteEmpresa>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "select ruc_cliente,razon_social,razon_comercial,direccion,telefono,email,contacto,codigo_persona,dni_vendedor from TBL_CLIENTE_EMPRESA where ruc_cliente='"+ ruc_cliente + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {          
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadClienteEmpresa entCliEmp = new EntidadClienteEmpresa()
                            {
                                ruc_cliente = dr["ruc_cliente"].ToString(),
                                razon_social = dr["razon_social"].ToString(),
                                razon_comercial = dr["razon_comercial"].ToString(),
                                direccion = dr["direccion"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                email = dr["email"].ToString(),
                                contacto = dr["contacto"].ToString(),
                                cod_persona = Convert.ToInt32(dr["codigo_persona"]),
                                dni_vendedor = dr["dni_vendedor"].ToString()

                            };
                            lst.Add(entCliEmp);
                        }
                    }

                }
            }
            return lst;
        }
        public static void InsertClienteEmpresa(EntidadClienteEmpresa entCliEmp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "INSERT INTO TBL_CLIENTE_EMPRESA(ruc_cliente,razon_social,razon_comercial,direccion,telefono,email,contacto,codigo_persona,dni_vendedor) VALUES('"+entCliEmp.ruc_cliente+"','"+entCliEmp.razon_social+"','"+entCliEmp.razon_comercial+"','"+entCliEmp.direccion+"','"+entCliEmp.telefono+"','"+entCliEmp.email+"','"+entCliEmp.contacto+"','"+entCliEmp.cod_persona+"','"+entCliEmp.dni_vendedor+"')  ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateClienteEmpresa(EntidadClienteEmpresa entCliEmp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "UPDATE TBL_CLIENTE_EMPRESA SET razon_social='" + entCliEmp.razon_social + "',razon_comercial='" + entCliEmp.razon_comercial + "',direccion='" + entCliEmp.direccion + "',telefono='" + entCliEmp.telefono + "',email='" + entCliEmp.email + "',contacto='" + entCliEmp.contacto + "',codigo_persona='" + entCliEmp.cod_persona + "',dni_vendedor='" + entCliEmp.dni_vendedor + "' WHERE ruc_cliente='" + entCliEmp.ruc_cliente + "'  ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
