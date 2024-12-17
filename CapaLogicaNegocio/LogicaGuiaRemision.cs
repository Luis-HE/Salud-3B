using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaGuiaRemision
    {
        public static void CreateGuiaRemision(EntidadGuiaRemision entGuiaRem)
        {
            DatosGuiaRemision.CreateGuiaRemision(entGuiaRem);
        }
        public static List<EntidadGuiaRemision> ReadGuiaRemision()
        {
            return DatosGuiaRemision.ReadGuiaRemision();
        }
        public static void UpdateGuiaRemision(EntidadGuiaRemision entGuiaRem)
        {
            DatosGuiaRemision.UpdateGuiaRemision(entGuiaRem);
        }
        public static void DeleteGuiaRemision(EntidadGuiaRemision entGuiaRem)
        {
            DatosGuiaRemision.DeleteGuiaRemision(entGuiaRem);
        }
    }
}
