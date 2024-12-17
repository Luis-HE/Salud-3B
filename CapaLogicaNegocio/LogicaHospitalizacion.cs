using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaHospitalizacion
    {
        public static List<EntidadHospitalizacion> ListHospitalizacion()
        {
            return DatosHospitalizacion.ListHospitalizacion();
        }
        public static void InsertHospitalizacion(EntidadHospitalizacion entHosp)
        {
            DatosHospitalizacion.InsertHospitalizacion(entHosp);
        }
    }
}
