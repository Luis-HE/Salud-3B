using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;
namespace CapaLogicaNegocio
{
   public class LogicaProveedor
    {
        public static void CreateProveedor(EntidadProveedor entProvee)
        {
            DatosProveedor.CreateProveedor(entProvee);
        }
        public static List<EntidadProveedor> ReadProveedor()
        {
            return DatosProveedor.ReadProveedor();
        }
        public static List<EntidadProveedor> ReadProveedor(string ruc_proveedor)
        {
            return DatosProveedor.ReadProveedor(ruc_proveedor);
        }
        public static void UpdateProveedor(EntidadProveedor entProvee)
        {
            DatosProveedor.UpdateProveedor(entProvee);
        }
        public static void DeleteProveedor(EntidadProveedor entProvee)
        {
            DatosProveedor.DeleteProveedor(entProvee);
        }
    }
}
