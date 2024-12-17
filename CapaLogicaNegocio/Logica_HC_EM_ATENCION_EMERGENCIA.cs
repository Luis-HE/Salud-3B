using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class Logica_HC_EM_ATENCION_EMERGENCIA
    {
        public static void CreateATENCION_EMERGENCIA(Entidad_HC_EM_ATENCION_EMERGENCIA ent)
        {
            Datos_HC_EM_ATENCION_EMERGENCIA.CreateATENCION_EMERGENCIA(ent);
        }
        public static List<Entidad_HC_EM_ATENCION_EMERGENCIA> ListATENCION_EMERGENCIA()
        {
            return Datos_HC_EM_ATENCION_EMERGENCIA.ListATENCION_EMERGENCIA();
        }
        public static void UPdateATENCION_EMERGENCIA(Entidad_HC_EM_ATENCION_EMERGENCIA ent)
        {
            Datos_HC_EM_ATENCION_EMERGENCIA.UPdateATENCION_EMERGENCIA(ent);
        }
        public static void DeteleATENCION_EMERGENCIA(int id_registro)
        {
            Datos_HC_EM_ATENCION_EMERGENCIA.DeteleATENCION_EMERGENCIA(id_registro);
        }
    }
}
