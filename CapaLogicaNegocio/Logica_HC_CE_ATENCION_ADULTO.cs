using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class Logica_HC_CE_ATENCION_ADULTO
    {
        public static void CreateATENCION_ADULTO(Entidad_HC_CE_ATENCION_ADULTO ent)
        {
            Datos_HC_CE_ATENCION_ADULTO.CreateATENCION_ADULTO(ent);
        }
        public static List<Entidad_HC_CE_ATENCION_ADULTO> ListATENCION_ADULTO()
        {
            return Datos_HC_CE_ATENCION_ADULTO.ListATENCION_ADULTO();
        }
        public static void UPdateATENCION_ADULTO(Entidad_HC_CE_ATENCION_ADULTO ent)
        {
            Datos_HC_CE_ATENCION_ADULTO.UPdateATENCION_ADULTO(ent);
        }
        public static void DeteleATENCION_ADULTO(int id_registro)
        {
            Datos_HC_CE_ATENCION_ADULTO.DeteleATENCION_ADULTO(id_registro);
        }
    }
}
