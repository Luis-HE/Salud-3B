using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaModelo
    {
        public static void CreateModelo(EntidadModelo entModelo)
        {
            DatosModelo.CreateModelo(entModelo);
        }
        public static List<EntidadModelo> ReadModelo()
        {
            return DatosModelo.ReadModelo();
        }
        public static void UpdateModelo(EntidadModelo entModelo)
        {
            DatosModelo.UpdateModelo(entModelo);
        }
        public static void DeleteModelo(EntidadModelo entModelo)
        {
            DatosModelo.DeleteModelo(entModelo);
        }
    }
}
