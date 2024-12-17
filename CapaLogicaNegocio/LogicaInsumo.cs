using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaInsumo
    {
        public static void CreateInsumo(EntidadInsumo entInsumo)
        {
            DatosInsumo.CreateInsumo(entInsumo);
        }
        public static List<EntidadInsumo> ReadInsumo()
        {
            return DatosInsumo.ReadInsumo();
        }
        public static void UpdateInsumo(EntidadInsumo entInsumo)
        {
            DatosInsumo.UpdateInsumo(entInsumo);
        }
        public static void DeleteInsumo(EntidadInsumo entInsumo)
        {
            DatosInsumo.DeleteInsumo(entInsumo);
        }
    }
}
