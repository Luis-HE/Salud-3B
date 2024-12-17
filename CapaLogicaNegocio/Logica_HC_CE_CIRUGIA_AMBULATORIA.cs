using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
  public  class Logica_HC_CE_CIRUGIA_AMBULATORIA
    {
        public static void InsertarCirugiaAmbulatoria(Entidad_HC_CE_CIRUGIA_AMBULATORIA ent)
        {
            Datos_HC_CE_CIRUGIA_AMBULATORIA.InsertarCirugiaAmbulatoria(ent);
        }
    }
}
