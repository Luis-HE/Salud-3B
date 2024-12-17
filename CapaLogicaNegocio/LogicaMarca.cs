using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaMarca
    {
        public static void CreateMarca(EntidadMarca entMarca)
        {
            DatosMarca.CreateMarca(entMarca);
        }
        public static List<EntidadMarca> ReadMarca()
        {
            return DatosMarca.ReadMarca();
        }
        public static void UpdateMarca(EntidadMarca entMarca)
        {
            DatosMarca.UpdateMarca(entMarca);
        }
        public static void DeleteMarca(EntidadMarca entMarca)
        {
            DatosMarca.DeleteMarca(entMarca);
        }
    }
}
