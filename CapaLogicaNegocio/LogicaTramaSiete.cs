using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaTramaSiete
    {
        public static List<EntidadTramaSiete> ListTramaSiete(int mes, int numero_tabla)
        {
            return DatosTramaSiete.ListTramaSiete(mes, numero_tabla);
        }
    }
}
