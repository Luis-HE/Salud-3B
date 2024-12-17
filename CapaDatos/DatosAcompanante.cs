using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

using CapaEntidad;

namespace CapaDatos
{
  public  class DatosAcompanante
    {
        public static List<EntidadAcompanante> ListAcompanante(string dni_ruc_acompana)
        {
            List<EntidadAcompanante> lst = new List<EntidadAcompanante>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select id_reg_acompanante,dni_ruc_acompanante,nombre_acompanante,codigo_persona,parentesco,nombre_contacto,ocupacion,telefono from TBL_ACOMPANANTE where dni_ruc_acompanante='" + dni_ruc_acompana+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadAcompanante entAcompana = new EntidadAcompanante()
                            {
                                id_reg_acompnante = Convert.ToInt32(dr["id_reg_acompanante"]),
                                dni_ruc_acompanante =  dr["dni_ruc_acompanante"].ToString(),
                                nombre_acompanante = dr["nombre_acompanante"].ToString(),
                                codigo_persona = Convert.ToInt32(dr["codigo_persona"]),
                                parentesco = dr["parentesco"].ToString(),
                                nombre_contacto = dr["nombre_contacto"].ToString(),
                                ocupacion = dr["ocupacion"].ToString(),
                                telefono = dr["telefono"].ToString()
                            };
                            lst.Add(entAcompana);
                        }
                    }

                }
            }

            return lst;
        }
        public static void InsertarAcompanante(EntidadAcompanante entAcomp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_ACOMPANANTE (id_reg_acompanante,dni_ruc_acompanante,codigo_persona,nombre_acompanante,apellido_acompanante,parentesco,nombre_contacto,ocupacion,telefono,grupo_etnico,idioma_principal,religion,estado_civil,genero,edad,grado_instruccion,condicion_ocupacion,seguro_salud) values(( SELECT ISNULL(MAX(id_reg_acompanante),0)+1 FROM TBL_ACOMPANANTE),'"+entAcomp.dni_ruc_acompanante+"','"+entAcomp.codigo_persona+ "' ,'" + entAcomp.nombre_acompanante + "','" + entAcomp.apellido_acompanante + "','" + entAcomp.parentesco + "','" + entAcomp.nombre_contacto + "','" + entAcomp.ocupacion + "','" + entAcomp.telefono + "','" + entAcomp.grupo_etnico + "','" + entAcomp.idioma_principal + "','" + entAcomp.religion + "','" + entAcomp.estado_civil + "','" + entAcomp.genero + "','" + entAcomp.edad + "','" + entAcomp.grado_instruccion + "','" + entAcomp.condicion_ocupacion + "','" + entAcomp.seguro_salud + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
