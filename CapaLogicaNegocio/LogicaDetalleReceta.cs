using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaDetalleReceta
    {
        public static void InsertarDetalleReceta(EntidadDetalleReceta entDetReceta)
        {
            DatosDetalleReceta.InsertarDetalleReceta(entDetReceta);
        }
    }
}
