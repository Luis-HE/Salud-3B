using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class Logica_HC_DG_DIAGNOSTICO
    {
        public static void InsertarDiagnostico(Entidad_HC_DG_DIAGNOSTICO ent)
        {
            Datos_HC_DG_DIAGNOSTICO.InsertarDiagnostico(ent);
        }
    }
}
