using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaArea
    {
        public static List<EntidadArea> ListArea()
        {
            return DatosArea.ListArea();
        }
    }
}
