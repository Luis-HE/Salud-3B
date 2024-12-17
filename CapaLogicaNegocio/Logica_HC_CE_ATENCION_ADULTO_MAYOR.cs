using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public  class Logica_HC_CE_ATENCION_ADULTO_MAYOR
    {
        public static void CreateATENCION_ADULTO_MAYOR(Entidad_HC_CE_ATENCION_ADULTO_MAYOR ent)
        {
            Datos_HC_CE_ATENCION_ADULTO_MAYOR.CreateATENCION_ADULTO_MAYOR(ent);
        }
        public static List<Entidad_HC_CE_ATENCION_ADULTO_MAYOR> ListATENCION_ADULTO_MAYOR()
        {
            return Datos_HC_CE_ATENCION_ADULTO_MAYOR.ListATENCION_ADULTO_MAYOR();
        }
        public static void UPdateATENCION_ADULTO_MAYOR(Entidad_HC_CE_ATENCION_ADULTO_MAYOR ent)
        {
            Datos_HC_CE_ATENCION_ADULTO_MAYOR.UPdateATENCION_ADULTO_MAYOR(ent);
        }
        public static void DeteleATENCION_ADULTO_MAYOR(int id_registro)
        {
            Datos_HC_CE_ATENCION_ADULTO_MAYOR.DeteleATENCION_ADULTO_MAYOR(id_registro);
        }
    }
}
