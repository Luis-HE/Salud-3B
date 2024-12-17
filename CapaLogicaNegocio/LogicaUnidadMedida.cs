using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaUnidadMedida
    {
        public static void CreateUnidadMedida(EntidadUnidadMedida entUnMed)
        {
            DatosUnidadMedida.CreateUnidadMedida(entUnMed);
        }
        public static List<EntidadUnidadMedida> ReadUnidadMedida()
        {
            return DatosUnidadMedida.ReadUnidadMedida();
        }
        public static void UpdateUnidadMedida(EntidadUnidadMedida entUnMed)
        {
            DatosUnidadMedida.UpdateUnidadMedida(entUnMed);
        }
        public static void DeleteUnidadMedida(EntidadUnidadMedida entUnMed)
        {
            DatosUnidadMedida.DeleteUnidadMedida(entUnMed);
        }
    }
}
