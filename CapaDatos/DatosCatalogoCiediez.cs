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
   public class DatosCatalogoCiediez
    {
        public static List<EntidadCatalogoCiediez> ListCatalogoCiediez()
        {
            List<EntidadCatalogoCiediez> lst = new List<EntidadCatalogoCiediez>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "SELECT codigo_ciediez,nombre FROM TBL_CIE10 ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadCatalogoCiediez entCatcie = new EntidadCatalogoCiediez()
                            {
                                codigo_ciediez = dr["codigo_ciediez"].ToString(),
                                nombre = dr["nombre"].ToString()
                            };
                            lst.Add(entCatcie);
                        }
                    }

                }
            }
            return lst;
        }

        public static List<EntidadCatalogoCiediez> ListCatalogoCiediez( string nombre)
        {
            List<EntidadCatalogoCiediez> lst = new List<EntidadCatalogoCiediez>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "SELECT cod_cie_diez,nombre FROM TBL_CIE10 WHERE nombre like '%" + nombre+"%' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadCatalogoCiediez entCatcie = new EntidadCatalogoCiediez()
                            {
                                codigo_ciediez = dr["cod_cie_diez"].ToString(),
                                nombre = dr["nombre"].ToString()
                            };
                            lst.Add(entCatcie);
                        }
                    }

                }
            }
            return lst;
        }

    }
}
