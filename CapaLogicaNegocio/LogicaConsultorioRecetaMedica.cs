using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public  class LogicaConsultorioRecetaMedica
    {
        public static void InsertarRecetaMedica(EntidadConsultorioRecetaMedica entReceta)
        {
            DatosConsultorioRecetaMedica.InsertarRecetaMedica(entReceta);
        }
        public static List<EntidadConsultorioRecetaMedica> GetLastIdRegReceta(string dni_cliente, int anio, int mes, int dia)
        {
            return DatosConsultorioRecetaMedica.GetLastIdRegReceta( dni_cliente,  anio,  mes,  dia);
        }
    }
}
