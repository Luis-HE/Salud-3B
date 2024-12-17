using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaAdmision
    {
        public static List<EntidadAdmision> ListAdmision()
        {
            return DatosAdmision.ListAdmision();
        }
        public static void InsertAdmision(EntidadAdmision entAdm)
        {
            DatosAdmision.InsertAdmision(entAdm);
        }
        public static void InsertAdmisionAmbulatoria(EntidadAdmision entAdm)
        {
            DatosAdmision.InsertAdmisionAmbulatoria(entAdm);
        }
        public static List<EntidadAdmision> GetLastIdRegAtencion(string dni_cliente, int cod_cia_seguro, int anio, int mes, int dia)
        {
            return DatosAdmision.GetLastIdRegAtencion(dni_cliente, cod_cia_seguro, anio, mes, dia);
        }
        public static void UpdateEstadoAdmision(int numero_admision)
        {
            DatosAdmision.UpdateEstadoAdmision(numero_admision);
        }
    }
}
