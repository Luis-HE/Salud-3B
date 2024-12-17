using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaProveedorSeguro
    {
        public static List<EntidadProveedorSeguro> ListProveedorSeguro()
        {
            return DatosProveedorSeguro.ListProveedorSeguro();
        }
        public static void InsertProveedorSeguro(EntidadProveedorSeguro entprovseg)
        {
            DatosProveedorSeguro.InsertProveedorSeguro(entprovseg);
        }
        public static void UpdateProveedorSeguro(EntidadProveedorSeguro entprovseg)
        {
            DatosProveedorSeguro.UpdateProveedorSeguro(entprovseg);
        }
        public static void DeleteProveedorSeguro(EntidadProveedorSeguro entprovseg)
        {
            DatosProveedorSeguro.DeleteProveedorSeguro(entprovseg);
        }
    }
}
