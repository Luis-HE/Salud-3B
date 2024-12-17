using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public  class Logica_HC_Lista_Atenciones
    {
        public static List<Entidad_HC_Lista_Atenciones> ListarAtencionesHC(string numero_dni)
        {
            return Datos_HC_Lista_Atenciones.ListarAtencionesHC(numero_dni);
        }
    }
}
