using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;
namespace CapaLogicaNegocio
{
   public class LogicaMoneda
    {
        public static void CreateMoneda(EntidadMoneda entMoneda)
        {
            DatosMoneda.CreateMoneda(entMoneda);
        }
        public static List<EntidadMoneda> ReadMoneda()
        {
            return DatosMoneda.ReadMoneda();
        }
        public static void UpdateMoneda(EntidadMoneda entMoneda)
        {
            DatosMoneda.UpdateMoneda(entMoneda);
        }
        public static void DeleteMoneda(EntidadMoneda entMoneda)
        {
            DatosMoneda.DeleteMoneda(entMoneda);
        }
    }
}
