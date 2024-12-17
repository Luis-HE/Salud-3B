using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaAlmacen
    {
        public static void CreateAlmacen(EntidadAlmacen entAlmacen)
        {
            DatosAlmacen.CreateAlmacen(entAlmacen);
        }
        public static List<EntidadAlmacen> ReadAlmacen()
        {
            return DatosAlmacen.ReadAlmacen();
        }
        public static void UpdateAlmacen(EntidadAlmacen entAlmacen)
        {
            DatosAlmacen.UpdateAlmacen(entAlmacen);
        }
        public static void DeleteAlmacen(EntidadAlmacen entAlmacen)
        {
            DatosAlmacen.DeleteAlmacen(entAlmacen);
        }
    }
}
