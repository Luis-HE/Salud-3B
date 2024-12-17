using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaModeloBuscaPacCitado
    {
        public static List<EntidadModeloBuscaPacCitado> ListarPaccitado(string dni_cliente, string fecha, string hora)
        {
            return DatosModeloBuscaPacCitado.ListarPaccitado(dni_cliente, fecha, hora);
        }
    }
}
