using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaEmpleado
    {
        public static List<EntidadEmpleado> ListEmpleados()
        {
            return DatosEmpleado.ListEmpleados();
        }
        public static List<EntidadEmpleado> ListEmpleados(int Id_area)
        {
            return DatosEmpleado.ListEmpleados(Id_area);
        }
        public static void InsertEmpleado(EntidadEmpleado entEmp)
        {
            DatosEmpleado.InsertEmpleado(entEmp);
        }
        public static void UpdateEmpleado(EntidadEmpleado entEmp)
        {
            DatosEmpleado.UpdateEmpleado(entEmp);
        }
    }
}
