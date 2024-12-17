using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public  class Logica_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN
    {
        public static void CreatePATOLOGIA_SOLICITUD_EXAMEN(Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN ent)
        {
            Datos_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN.CreatePATOLOGIA_SOLICITUD_EXAMEN(ent);

        }
        public static List<Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN> ListPATOLOGIA_SOLICITUD_EXAMEN()
        {
            return Datos_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN.ListPATOLOGIA_SOLICITUD_EXAMEN();
        }
        public static void UPdatePATOLOGIA_SOLICITUD_EXAMEN(Entidad_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN ent)
        {
            Datos_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN.UPdatePATOLOGIA_SOLICITUD_EXAMEN(ent);
        }
        public static void DetelePATOLOGIA_SOLICITUD_EXAMEN(int id_solicitud_examen)
        {
            Datos_TBL_HC_FESP_PATOLOGIA_SOLICITUD_EXAMEN.DetelePATOLOGIA_SOLICITUD_EXAMEN(id_solicitud_examen);
        }
    }
}
