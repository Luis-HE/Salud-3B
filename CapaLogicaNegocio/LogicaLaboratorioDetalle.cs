using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaLaboratorioDetalle
    {
        public static void InsertarLaboratorioDetalle(EntidadLaboratorioDetalle ent)
        {
            DatosLaboratorioDetalle.InsertarLaboratorioDetalle(ent);
        }
    }
}
