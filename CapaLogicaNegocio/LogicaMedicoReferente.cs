using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace CapaLogicaNegocio
{
   public class LogicaMedicoReferente
    {
        public static List<EntidadMedicoReferente> ListMedicoReferente(string apellido_paterno)
        {
            return DatosMedicoReferente.ListMedicoReferente(apellido_paterno);
        }
    }
}
