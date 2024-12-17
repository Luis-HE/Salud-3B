using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaEspecialidad
    {
        public static List<EntidadEspecialidad> ListEspecialidad()
        {
            return DatosEspecialidad.ListEspecialidad();
        }
    }
}
