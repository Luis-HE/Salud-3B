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
   public class DatosConvenio
    {
        public static List<EntidadConvenio> ListConvenios()
        {
            List<EntidadConvenio> lst = new List<EntidadConvenio>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "SELECT id_reg_convenio, id_cia_seguro,duracion,firmante_convenio,observacion,fecha_convenio FROM TBL_CONVENIO order by id_reg_convenio DESC";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadConvenio entcon = new EntidadConvenio()
                            {
                                id_reg_convenio = Convert.ToInt32(dr["id_reg_convenio"]),
                                id_cia_seguro = Convert.ToInt32(dr["id_cia_seguro"]),
                                duracion = dr["duracion"].ToString(),
                                firmante = dr["firmante_convenio"].ToString(),
                                observacion = dr["observacion"].ToString(),
                                fecha_convenio = dr["fecha_convenio"].ToString()  
                            };
                            lst.Add(entcon);
                        }
                    }
                    
                }

            }

                return lst;
        }
        public static void InsertConvenio(EntidadConvenio entcon)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_CONVENIO(id_reg_convenio, id_cia_seguro,duracion,firmante_convenio,observacion,fecha_convenio) VALUES('"+entcon.id_reg_convenio+"','" + entcon.id_cia_seguro + "','" + entcon.duracion + "','" + entcon.firmante + "','" + entcon.observacion + "' ,'" + entcon.fecha_convenio + "')";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();                  
                }

            }
        }
        public static void UpdateConvenio(EntidadConvenio entcon)
        {

        }
        public static void DeleteConvenio(EntidadConvenio entcon)
        {

        }
    }
}
