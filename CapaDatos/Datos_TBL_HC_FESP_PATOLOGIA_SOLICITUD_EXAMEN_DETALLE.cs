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
   public class Datos_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE
    {
        public static void CreatePATOLOGIA_SOLICITUD_EXAMEN_DETALLE(Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE(id_solicitud_examen_detalle,id_patologia_solicitud_examen,numero_historia_clinica,numero_doc_cliente,codigo_persona,codigo_item_catalogo,id_grupo,id_clase,descripcion_item,estado,cantidad_solicita ) values('" + ent.id_solicitud_examen_detalle + "','" + ent.id_patologia_solictud_examen + "' ,'" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.codigo_item_catalogo + "','" + ent.id_grupo + "','" + ent.id_clase + "','" + ent.descripcion_item + "','" + ent.estado + "','" + ent.cantidad_solicita + "' )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static List<Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE> ListPATOLOGIA_SOLICITUD_EXAMEN_DETALLE()
        {
            List<Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE> lst = new List<Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE>();

            return lst;
        }
        public static void UPdatePATOLOGIA_SOLICITUD_EXAMEN_DETALLE(Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE ent)
        {

        }
        public static void DetelePATOLOGIA_SOLICITUD_EXAMEN_DETALLE(int id_registro_solicitud_detalle)
        {

        }
    }
}
