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
   public class DatosProveedor
    {
        public static void CreateProveedor(EntidadProveedor entProvee)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "INSERT INTO TBL_PROVEEDOR(ruc_proveedor,razon_social,razon_comercial,direccion,email,telefono,representante,codigo_persona_pago,numero_cuenta,nombre_banco) VALUES('"+entProvee.ruc_proveedor+"','"+entProvee.razon_social+"','"+entProvee.razon_comercial+"','"+entProvee.direccion+"','"+entProvee.email+"','"+entProvee.telefono+"','"+entProvee.representante+"','"+entProvee.cod_persona_pago+"','"+entProvee.numero_cuenta+"','"+entProvee.nombre_banco+"') ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<EntidadProveedor> ReadProveedor()
        {
            List<EntidadProveedor> lst = new List<EntidadProveedor>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "SELECT ruc_proveedor,razon_social,razon_comercial,direccion,email,telefono,representante,codigo_persona_pago,numero_cuenta,nombre_banco FROM TBL_PROVEEDOR ORDER BY razon_social ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadProveedor entProv = new EntidadProveedor()
                            {
                                ruc_proveedor = dr["ruc_proveedor"].ToString(),
                                razon_social = dr["razon_social"].ToString(),
                                razon_comercial = dr["razon_comercial"].ToString(),
                                direccion = dr["direccion"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                email = dr["email"].ToString(),
                                representante = dr["representante"].ToString(),
                                cod_persona_pago = Convert.ToInt32(dr["codigo_persona_pago"]),
                                numero_cuenta = dr["numero_cuenta"].ToString(),
                                nombre_banco = dr["nombre_banco"].ToString()

                            };
                            lst.Add(entProv);
                        }
                    }

                }
            }
            return lst;
        }
        public static List<EntidadProveedor> ReadProveedor(string ruc_proveedor)
        {
            List<EntidadProveedor> lst = new List<EntidadProveedor>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "SELECT ruc_proveedor,razon_social,razon_comercial,direccion,email,telefono,representante,codigo_persona_pago,numero_cuenta,nombre_banco FROM TBL_PROVEEDOR where ruc_proveedor='"+ruc_proveedor+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadProveedor entProv = new EntidadProveedor()
                            {
                                ruc_proveedor = dr["ruc_proveedor"].ToString(),
                                razon_social = dr["razon_social"].ToString(),
                                razon_comercial = dr["razon_comercial"].ToString(),
                                direccion = dr["direccion"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                email = dr["email"].ToString(),
                                representante = dr["representante"].ToString(),
                                cod_persona_pago = Convert.ToInt32(dr["codigo_persona_pago"]),
                                numero_cuenta = dr["numero_cuenta"].ToString(),
                                nombre_banco = dr["nombre_banco"].ToString()

                            };
                            lst.Add(entProv);
                        }
                    }

                }
            }
            return lst;
        }
        public static void UpdateProveedor(EntidadProveedor entProvee)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "UPDATE TBL_PROVEEDOR SET razon_social='" + entProvee.razon_social + "',razon_comercial='" + entProvee.razon_comercial + "',direccion='" + entProvee.direccion + "',email='" + entProvee.email + "',telefono='" + entProvee.telefono + "',representante='" + entProvee.representante + "',codigo_persona_pago='" + entProvee.cod_persona_pago + "',numero_cuenta='" + entProvee.numero_cuenta + "',nombre_banco='" + entProvee.nombre_banco + "'  WHERE ruc_proveedor='" + entProvee.ruc_proveedor + "'  ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteProveedor(EntidadProveedor entProvee)
        {

        }
    }
}
