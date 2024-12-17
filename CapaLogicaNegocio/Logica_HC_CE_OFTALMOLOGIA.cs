using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class Logica_HC_CE_OFTALMOLOGIA
    {
        public static void InserOftalmologia(Entidad_HC_CE_OFTALMOLOGIA ent)
        {
            Datos_HC_CE_OFTALMOLOGIA.InserOftalmologia(ent);
        }
    }
}
