using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;
namespace CapaLogicaNegocio
{
   public class LogicaSucursal
    {
        public static void CreateSucursal(EntidadSucursal entSucursal)
        {
            DatosSucursal.CreateSucursal(entSucursal);
        }
        public static List<EntidadSucursal> ReadSucursal()
        {
            return DatosSucursal.ReadSucursal();
        }
        public static void UpdateSucursal(EntidadSucursal entSucursal)
        {
            DatosSucursal.UpdateSucursal(entSucursal);
        }
        public static void DeleteSucursal(EntidadSucursal entSucursal)
        {
            DatosSucursal.DeleteSucursal(entSucursal);
        }
    }
}
