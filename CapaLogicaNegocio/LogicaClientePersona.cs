using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaClientePersona
    {
        public static List<EntidadClientePersona> ListClientePersona()
        {
            return DatosClientePersona.ListClientePersona();
        }
        public static List<EntidadClientePersona> ListClientePersona(string dni)
        {
            return DatosClientePersona.ListClientePersona(dni);
        }
        public static void InsertClientePersona(EntidadClientePersona entcp)
        {
            DatosClientePersona.InsertClientePersona(entcp);
        }
        public static void UpdateClientePersona(EntidadClientePersona entcp)
        {
            DatosClientePersona.UpdateClientePersona(entcp);
        }
    }
}
