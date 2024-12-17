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
   public class DatosProveedorSeguro
    {
        public static List<EntidadProveedorSeguro> ListProveedorSeguro()
        {
            List<EntidadProveedorSeguro> lst = new List<EntidadProveedorSeguro>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select id_cia_seguro,codigo_persona_pago,ruc_proveedor,nombre_cia_seguro from TBL_PROVEEDOR_SEGURO";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadProveedorSeguro entprovseg = new EntidadProveedorSeguro()
                            {
                                id_cia_seguro = Convert.ToInt32(dr["id_cia_seguro"]),
                                codigo_persona_pago = Convert.ToInt32(dr["codigo_persona_pago"]),
                                ruc_proveedor = dr["ruc_proveedor"].ToString(),
                                nombre_seguro = dr["nombre_cia_seguro"].ToString()
                            };
                            lst.Add(entprovseg);
                        }
                    }
                    
                }

            }

            return lst;
        }
        public static void InsertProveedorSeguro(EntidadProveedorSeguro entprovseg)
        {

        }
        public static void UpdateProveedorSeguro(EntidadProveedorSeguro entprovseg)
        {

        }
        public static void DeleteProveedorSeguro(EntidadProveedorSeguro entprovseg)
        {

        }
    }
}
