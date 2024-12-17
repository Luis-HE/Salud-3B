using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaCita
    {
        public static List<EntidadCita> ListCitas(string dni_paciente)
        {
            return DatosCita.ListCitas(dni_paciente);
        }
        public static void InsertCita(EntidadCita entcita)
        {
            DatosCita.InsertCita(entcita);
        }
        public static List<EntidadCita> GetLastIdRegCita(string dni_cliente, string fecha_cita, int anio, int mes, int dia)
        {
            return DatosCita.GetLastIdRegCita(dni_cliente, fecha_cita, anio, mes, dia);
        }
    }
}
