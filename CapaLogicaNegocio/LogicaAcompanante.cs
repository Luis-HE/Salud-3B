using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace CapaLogicaNegocio
{
 public   class LogicaAcompanante
    {
        public static List<EntidadAcompanante> ListAcompanante(string dni_ruc_acompana)
        {
            return DatosAcompanante.ListAcompanante(dni_ruc_acompana);
        }
        public static void InsertarAcompanante(EntidadAcompanante entAcomp)
        {
            DatosAcompanante.InsertarAcompanante(entAcomp);
        }
    }
}
