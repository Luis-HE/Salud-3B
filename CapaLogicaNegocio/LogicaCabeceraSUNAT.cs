using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
  public  class LogicaCabeceraSUNAT
    {
        public static List<EntidadCabeceraSUNAT> ListarCabecera(string numero_documento, string serie, string tipo_documento)
        {
            return DatosCabeceraSUNAT.ListarCabecera( numero_documento,  serie,  tipo_documento);
        }
    }
}
