using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaClienteSUNAT
    {
        public static List<EntidadClienteSUNAT> listarClienteSUNAT(string numero_documento, string serie, string tipo_documento)
        {
            return DatosClienteSUNAT.listarClienteSUNAT(numero_documento, serie, tipo_documento);
        }
    }
}
