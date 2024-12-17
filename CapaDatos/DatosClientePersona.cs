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
   public class DatosClientePersona
    {
        public static List<EntidadClientePersona> ListClientePersona()
        {
            List<EntidadClientePersona> lst = new List<EntidadClientePersona>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select numero_doc_cliente,apellido_paterno,apellido_materno,nombres,telefono1,email,telefono2,genero,codigo_persona,dni_vendedor,direccion,grupo_sanguineo,fecha_nace,codigo_nacionalidad,id_ubigeo,grupo_etnico,estado_civil,nombre_padre,nombre_madre,religion,ocupacion from TBL_CLIENTE_PERSONA ORDER BY apellido_paterno ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadClientePersona entcp = new EntidadClientePersona()
                            {
                                num_doc_cliente = dr["numero_doc_cliente"].ToString(),
                                cod_persona = Convert.ToInt32(dr["codigo_persona"]),
                                apellido_paterno = dr["apellido_paterno"].ToString(),
                                apellido_materno = dr["apellido_materno"].ToString(),
                                nombres = dr["nombres"].ToString(),
                                telefono1 = dr["telefono1"].ToString(),
                                email = dr["email"].ToString(),
                                telefono2 = dr["telefono2"].ToString(),
                                genero = dr["genero"].ToString(),
                                dni_vendedor = dr["dni_vendedor"].ToString(),
                                direccion = dr["direccion"].ToString(),
                                grupo_sanguineo = dr["grupo_sanguineo"].ToString(),
                                fecha_nace = dr["fecha_nace"].ToString(),
                                cod_nacionalidad = Convert.ToInt32(dr["codigo_nacionalidad"]),
                                id_ubigeo =  dr["id_ubigeo"].ToString(),
                                estado_civil = dr["estado_civil"].ToString(),
                                nombre_padre = dr["nombre_padre"].ToString(),
                                nombre_madre = dr["nombre_madre"].ToString(),
                                religion = dr["religion"].ToString(),
                                ocupacion = dr["ocupacion"].ToString(),
                                grupo_etnico = dr["grupo_etnico"].ToString()
                            };
                            lst.Add(entcp);
                        }
                    }

                }

            }
            return lst;
        }
        public static List<EntidadClientePersona> ListClientePersona(string dni)
        {
            List<EntidadClientePersona> lst = new List<EntidadClientePersona>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select numero_doc_cliente,apellido_paterno,apellido_materno,nombres,telefono1,email,telefono2,genero,codigo_persona,dni_vendedor,direccion,grupo_sanguineo,fecha_nace,codigo_nacionalidad,id_ubigeo,grupo_etnico,estado_civil,nombre_padre,nombre_madre,religion,ocupacion from TBL_CLIENTE_PERSONA where numero_doc_cliente='" + dni+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadClientePersona entcp = new EntidadClientePersona()
                            {
                                num_doc_cliente = dr["numero_doc_cliente"].ToString(),
                                cod_persona = Convert.ToInt32(dr["codigo_persona"]),
                                apellido_paterno = dr["apellido_paterno"].ToString(),
                                apellido_materno = dr["apellido_materno"].ToString(),
                                nombres = dr["nombres"].ToString(),
                                telefono1 = dr["telefono1"].ToString(),
                                email = dr["email"].ToString(),
                                telefono2 = dr["telefono2"].ToString(),
                                genero = dr["genero"].ToString(),
                                dni_vendedor = dr["dni_vendedor"].ToString(),
                                direccion = dr["direccion"].ToString(),
                                grupo_sanguineo = dr["grupo_sanguineo"].ToString(),
                                fecha_nace = dr["fecha_nace"].ToString(),
                                cod_nacionalidad = Convert.ToInt32(dr["codigo_nacionalidad"]),
                                id_ubigeo =  dr["id_ubigeo"].ToString(),
                                estado_civil = dr["estado_civil"].ToString(),
                                nombre_padre = dr["nombre_padre"].ToString(),
                                nombre_madre = dr["nombre_madre"].ToString(),
                                religion = dr["religion"].ToString(),
                                ocupacion = dr["ocupacion"].ToString(),
                                grupo_etnico = dr["grupo_etnico"].ToString()

                            };
                            lst.Add(entcp);
                        }
                    }
                   
                }

            }
                return lst;
        }
        public static void InsertClientePersona(EntidadClientePersona entcp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_CLIENTE_PERSONA(numero_doc_cliente,codigo_persona,apellido_paterno,nombres,apellido_materno,telefono1,telefono2,email,genero,dni_vendedor,direccion,grupo_sanguineo,fecha_nace,codigo_nacionalidad,id_ubigeo,estado_civil,nombre_padre,nombre_madre,religion,ocupacion,grupo_etnico) VALUES('" + entcp.num_doc_cliente+ "','" + entcp.cod_persona + "','" + entcp.apellido_paterno+ "','" + entcp.nombres + "','" + entcp.apellido_materno+"','"+entcp.telefono1+"','"+entcp.telefono2+ "','" + entcp.email + "','" + entcp.genero+"','"+entcp.dni_vendedor+"','"+entcp.direccion+"','"+entcp.grupo_sanguineo+"','"+entcp.fecha_nace+"','"+entcp.cod_nacionalidad+"','"+entcp.id_ubigeo+"','"+entcp.estado_civil+"','"+entcp.nombre_padre+"','"+entcp.nombre_madre+"','"+entcp.religion+"','"+entcp.ocupacion+ "','" + entcp.grupo_etnico + "' ) ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                         cmd.ExecuteNonQuery();                   
                }
            }
        }
        public static void UpdateClientePersona(EntidadClientePersona entcp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "UPDATE TBL_CLIENTE_PERSONA SET apellido_paterno='" + entcp.apellido_paterno + "',apellido_materno='" + entcp.apellido_materno + "',nombres='" + entcp.nombres + "',telefono1='" + entcp.telefono1 + "',email='" + entcp.email + "',telefono2='" + entcp.telefono2 + "',genero='" + entcp.genero + "',direccion='" + entcp.direccion + "',grupo_sanguineo='" + entcp.grupo_sanguineo + "',fecha_nace='" + entcp.fecha_nace + "'  WHERE numero_doc_cliente='" + entcp.num_doc_cliente + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteClientePersona(EntidadClientePersona entcp)
        {

        }
        
    }
}
