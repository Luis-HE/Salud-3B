using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace CapaLogicaNegocio
{
   public class LogicaUbigeo
    {
        public static List<EntidadUbigeo> ListarUbigeo()
        {
           return DatosUbigeo.ListarUbigeo();
        }
    }
}
