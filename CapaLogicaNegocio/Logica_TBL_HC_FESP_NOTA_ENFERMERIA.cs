using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class Logica_TBL_HC_FESP_NOTA_ENFERMERIA
    {
        public static void CreateNOTAS_ENFERMERIA(Entidad_TBL_HC_FESP_NOTA_ENFERMERIA ent)
        {
            Datos_TBL_HC_FESP_NOTA_ENFERMERIA.CreateNOTAS_ENFERMERIA(ent);
        }
        public static List<Entidad_TBL_HC_FESP_NOTA_ENFERMERIA> ListNOTAS_ENFERMERIA()
        {
            return Datos_TBL_HC_FESP_NOTA_ENFERMERIA.ListNOTAS_ENFERMERIA();
        }
        public static void UPdateNOTAS_ENFERMERIA(Entidad_TBL_HC_FESP_NOTA_ENFERMERIA ent)
        {
            Datos_TBL_HC_FESP_NOTA_ENFERMERIA.UPdateNOTAS_ENFERMERIA(ent);
        }
        public static void DeteleNOTAS_ENFERMERIA(int id_registro)
        {
            Datos_TBL_HC_FESP_NOTA_ENFERMERIA.DeteleNOTAS_ENFERMERIA(id_registro);
        }
    }
}
