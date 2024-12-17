using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaProgramadorTurnos
    {
        public static List<EntidadProgramadorTurnos> ListProgramadorTurnos(EntidadProgramadorTurnos entprogT)
        {
            return DatosProgramadorTurnos.ListProgramadorTurnos(entprogT);
        }
    }
}
