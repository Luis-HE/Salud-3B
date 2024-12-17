using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaDetalleCita
    {
        public static List<EntidadDetalleCita> ListDetalleCita(int Num_cita)
        {
            return DatosDetalleCita.ListDetalleCita(Num_cita);
        }
        public static void InsertDetalleCita(EntidadDetalleCita entDetCita)
        {
            DatosDetalleCita.InsertDetalleCita(entDetCita);
        }
        public static void ActualizaEstadoDetalleCita(string dni_paciente, int codigo_especialidad, string hora, string fecha_cita)
        {
            DatosDetalleCita.ActualizaEstadoDetalleCita( dni_paciente,  codigo_especialidad,  hora,  fecha_cita);
        }
    }
}
