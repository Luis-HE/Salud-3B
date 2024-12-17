using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class Logica_HC_CE_ATENCION_NINO
    {
        public static void CreateATENCION_NINO(Entidad_HC_CE_ATENCION_NINO ent)
        {
            Datos_HC_CE_ATENCION_NINO.CreateATENCION_NINO(ent);
        }
        public static List<Entidad_HC_CE_ATENCION_NINO> ListATENCION_NINO()
        {
            return Datos_HC_CE_ATENCION_NINO.ListATENCION_NINO();
        }
        public static void UPdateATENCION_NINO(Entidad_HC_CE_ATENCION_NINO ent)
        {
            Datos_HC_CE_ATENCION_NINO.UPdateATENCION_NINO(ent);
        }
        public static void DeteleATENCION_NINO(int id_registro_atencion)
        {
            Datos_HC_CE_ATENCION_NINO.DeteleATENCION_NINO(id_registro_atencion);
        }
    }
}
