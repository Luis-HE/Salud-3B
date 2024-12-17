using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class Logica_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE
    {
        public static void CreatePATOLOGIA_SOLICITUD_EXAMEN_DETALLE(Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE ent)
        {
            Datos_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE.CreatePATOLOGIA_SOLICITUD_EXAMEN_DETALLE(ent);

        }
        public static List<Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE> ListPATOLOGIA_SOLICITUD_EXAMEN_DETALLE()
        {
            return Datos_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE.ListPATOLOGIA_SOLICITUD_EXAMEN_DETALLE();
        }
        public static void UPdatePATOLOGIA_SOLICITUD_EXAMEN_DETALLE(Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE ent)
        {
            Datos_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE.UPdatePATOLOGIA_SOLICITUD_EXAMEN_DETALLE(ent);
        }
        public static void DetelePATOLOGIA_SOLICITUD_EXAMEN_DETALLE(int id_registro_solicitud_detalle)
        {
            Datos_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN_DETALLE.DetelePATOLOGIA_SOLICITUD_EXAMEN_DETALLE(id_registro_solicitud_detalle);
        }
    }
}
