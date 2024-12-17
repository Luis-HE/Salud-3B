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
   public class DatosAlmacen
    {
        public static void CreateAlmacen(EntidadAlmacen entAlmacen)
        {

        }
        public static List<EntidadAlmacen> ReadAlmacen()
        {
            List<EntidadAlmacen> lst = new List<EntidadAlmacen>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select codigo_almacen,nombre,direccion from TBL_ALMACEN";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            EntidadAlmacen antAlm = new EntidadAlmacen()
                            {
                                codigo_almacen = Convert.ToInt32(dr["codigo_almacen"]),
                                nombre = dr["nombre"].ToString(),
                                direccion = dr["direccion"].ToString()

                            };
                            lst.Add(antAlm);
                        }
                    }
                }

            }
                return lst;
        }
        public static void UpdateAlmacen(EntidadAlmacen entAlmacen)
        {

        }
        public static void DeleteAlmacen(EntidadAlmacen entAlmacen)
        {

        }
    }
}
