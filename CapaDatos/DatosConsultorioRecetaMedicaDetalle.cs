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
   public  class DatosConsultorioRecetaMedicaDetalle
    {
        public static void InsertarRecetaMedicaDetalle(EntidadConsultorioRecetaMedicaDetalle entR)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "INSERT INTO TBL_CONSULTORIO_RECETA_MEDICA_DETALLE(id_det_receta,id_receta,codigo_item_catalogo,id_grupo,id_clase,cantidad_receta,forma_farmaceutica,estado,descripcion_item,concentracion,via_administracion, frecuencia, tratamiento ) VALUES( (SELECT ISNULL(MAX(id_det_receta),0)+1 FROM TBL_CONSULTORIO_RECETA_MEDICA_DETALLE) ,'" + entR.id_receta + "','" + entR.codigo_item_catalogo + "' ,'" + entR.id_grupo + "','" + entR.id_clase + "','" + entR.cantidad_receta + "','" + entR.forma_farmaceutica + "','" + entR.estado + "','" + entR.descripcion_item + "', '" + entR.concentracion + "','" + entR.via_administracion + "','" + entR.frecuencia + "','" + entR.tratamiento + "'  ) ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void ActualizarEstadoItemReceta(string codigo_item_catalogo, int numero_admision)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "update TBL_CONSULTORIO_RECETA_MEDICA_DETALLE  set estado=1 WHERE codigo_item_catalogo='"+codigo_item_catalogo+"' and id_receta = (select id_receta from TBL_CONSULTORIO_RECETA_MEDICA WHERE numero_admision = '"+numero_admision+"') ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
