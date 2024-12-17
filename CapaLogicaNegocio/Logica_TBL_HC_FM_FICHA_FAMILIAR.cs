using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
    public class Logica_TBL_HC_FM_FICHA_FAMILIAR
    {
        public static void CreateFICHA_FAMILIAR(Entidad_TBL_HC_FM_FICHA_FAMILIAR ent)
        {
            Datos_TBL_HC_FM_FICHA_FAMILIAR.CreateFICHA_FAMILIAR(ent);

        }
        public static List<Entidad_TBL_HC_FM_FICHA_FAMILIAR> ListFICHA_FAMILIAR()
        {
            return Datos_TBL_HC_FM_FICHA_FAMILIAR.ListFICHA_FAMILIAR();
        }
        public static void UPdateFICHA_FAMILIAR(Entidad_TBL_HC_FM_FICHA_FAMILIAR ent)
        {
            Datos_TBL_HC_FM_FICHA_FAMILIAR.UPdateFICHA_FAMILIAR(ent);
        }
        public static void DeteleFICHA_FAMILIAR(int id_registro_ficha_familiar)
        {
            Datos_TBL_HC_FM_FICHA_FAMILIAR.DeteleFICHA_FAMILIAR(id_registro_ficha_familiar);
        }

    }
}
