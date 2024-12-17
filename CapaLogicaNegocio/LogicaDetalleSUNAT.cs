using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
  public   class LogicaDetalleSUNAT
    {
        public static List<EntidadDetalleSUNAT> listarDetalle(string numero_documento, string serie, string tipo_documento)
        {
            return DatosDetalleSUNAT.listarDetalle(numero_documento, serie, tipo_documento);
        }
    }
}
