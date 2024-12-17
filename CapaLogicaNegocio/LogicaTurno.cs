using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaTurno
    {
        public static List<EntidadTurno> ListTurnos(string fecha, int cod_especialidad)
        {
            return DatosTurno.ListTurnos(fecha, cod_especialidad);
        }
        public static void InsertTurno(EntidadTurno entTurno)
        {
            DatosTurno.InsertTurno(entTurno);
        }
        public static void DeleteTurno(EntidadTurno entTurno)
        {
            DatosTurno.DeleteTurno(entTurno);
        }
        public static void OcuparTurno(string dni_paciente, string hora, string fechaocupar, int cod_especialidad, string cod_item_catalogo)
        {
            DatosTurno.OcuparTurno(dni_paciente, hora, fechaocupar, cod_especialidad, cod_item_catalogo);
        }
        public static void DesocuparTurno(int id_regTurno, string hora, int codigo_especialidad)
        {
            DatosTurno.DesocuparTurno(id_regTurno, hora, codigo_especialidad);
        }
    }
}
