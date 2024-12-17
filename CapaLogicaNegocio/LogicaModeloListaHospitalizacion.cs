using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaModeloListaHospitalizacion
    {
        public static List<EntidadModeloListaHospitalizacion> ListParaHospitalizacion(int dia, int mes, int anio)
        {
            return DatosModeloListaHospitalizacion.ListParaHospitalizacion( dia,  mes, anio);
        }
    }
}
