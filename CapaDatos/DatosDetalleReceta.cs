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
   public class DatosDetalleReceta
    {
        public static void InsertarDetalleReceta(EntidadDetalleReceta entDetReceta)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "INSERT INTO TBL_DET_RECETA(id_det_receta,id_receta,codigo_item_catalogo,id_grupo,id_clase,cantidad_receta,forma_farmaceutica,indicaciones) VALUES( (SELECT ISNULL(MAX(id_det_receta),0)+1 FROM TBL_DET_RECETA)  ,'" + entDetReceta.id_receta+"','"+entDetReceta.cod_item_catalogo+ "','" + entDetReceta.id_grupo + "','" + entDetReceta.id_clase + "','" + entDetReceta.cantidad_receta + "','" + entDetReceta.forma_farmaceutica + "','" + entDetReceta.indicaciones + "' ) ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
