using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaDetalleAdmision
    {
        public static List<EntidadDetalleAdmision> ListDetalleAdmision(int numero_admision)
        {
            return DatosDetalleAdmision.ListDetalleAdmision(numero_admision);
        }
        public static void InsertDetalleAdmision(EntidadDetalleAdmision entDetAdm)
        {
            DatosDetalleAdmision.InsertDetalleAdmision(entDetAdm);
        }
    }
}
