using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
  public  class Logica_HC_CE_ATENCION_ADOLECENTE
    {
        public static void CreateATENCION_ADOLECENTE(Entidad_HC_CE_ATENCION_ADOLECENTE ent)
        {
            Datos_HC_CE_ATENCION_ADOLECENTE.CreateATENCION_ADOLECENTE(ent);
        }
        public static List<Entidad_HC_CE_ATENCION_ADOLECENTE> ListATENCION_ADOLECENTE()
        {
            return Datos_HC_CE_ATENCION_ADOLECENTE.ListATENCION_ADOLECENTE();
        }
        public static void UPdateATENCION_ADOLECENTE(Entidad_HC_CE_ATENCION_ADOLECENTE ent)
        {
            Datos_HC_CE_ATENCION_ADOLECENTE.UPdateATENCION_ADOLECENTE(ent);
        }
        public static void DeteleATENCION_ADOLECENTE(int id_registro)
        {
            Datos_HC_CE_ATENCION_ADOLECENTE.DeteleATENCION_ADOLECENTE(id_registro);
        }
    }
}
