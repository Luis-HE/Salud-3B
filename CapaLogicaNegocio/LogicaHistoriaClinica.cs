using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
  public  class LogicaHistoriaClinica
    {
        public static void InsertarHistoriaClinica(EntidadHistoriaClinica enthc)
        {
            DatosHistoriaClinica.InsertarHistoriaClinica(enthc);
        }
    }
}
