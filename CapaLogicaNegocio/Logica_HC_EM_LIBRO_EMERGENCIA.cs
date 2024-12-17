using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class Logica_HC_EM_LIBRO_EMERGENCIA
    {
        public static void CreateLIBRO_EMERGENCIA(Entidad_HC_EM_LIBRO_EMERGENCIA ent)
        {
            Datos_HC_EM_LIBRO_EMERGENCIA.CreateLIBRO_EMERGENCIA(ent);
        }
        public static List<Entidad_HC_EM_LIBRO_EMERGENCIA> ListLIBRO_EMERGENCIA()
        {
            return Datos_HC_EM_LIBRO_EMERGENCIA.ListLIBRO_EMERGENCIA();
        }
        public static void UPdateLIBRO_EMERGENCIA(Entidad_HC_EM_LIBRO_EMERGENCIA ent)
        {
            Datos_HC_EM_LIBRO_EMERGENCIA.UPdateLIBRO_EMERGENCIA(ent);
        }
        public static void DeteleLIBRO_EMERGENCIA(int id_registro)
        {
            Datos_HC_EM_LIBRO_EMERGENCIA.DeteleLIBRO_EMERGENCIA(id_registro);
        }
    }
}
