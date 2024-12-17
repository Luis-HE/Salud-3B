using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public  class Logica_HC_CE_ATENCION_JOVEN
    {
        public static void CreateATENCION_JOVEN(Entidad_HC_CE_ATENCION_JOVEN ent)
        {
            Datos_HC_CE_ATENCION_JOVEN.CreateATENCION_JOVEN(ent);
        }
        public static List<Entidad_HC_CE_ATENCION_JOVEN> ListATENCION_JOVEN()
        {
            return Datos_HC_CE_ATENCION_JOVEN.ListATENCION_JOVEN();
        }
        public static void UPdateATENCION_JOVEN(Entidad_HC_CE_ATENCION_JOVEN ent)
        {
            Datos_HC_CE_ATENCION_JOVEN.UPdateATENCION_JOVEN(ent);
        }
        public static void DeteleATENCION_JOVEN(int id_registro)
        {
            Datos_HC_CE_ATENCION_JOVEN.DeteleATENCION_JOVEN(id_registro);
        }
    }
}
