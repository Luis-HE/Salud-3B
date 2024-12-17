using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class Logica_HC_CE_GINECO_OBSTETRICIA
    {
        public static void InsertarGinecoObstetrica(Entidad_HC_CE_GINECO_OBSTETRICIA ent)
        {
            Datos_HC_CE_GINECO_OBSTETRICIA.InsertarGinecoObstetrica(ent);
        }
    }
}
