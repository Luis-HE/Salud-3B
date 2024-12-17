using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
  public  class LogicaLaboratorio
    {
        public static void InsertarLaboratorio(EntidadLaboratorio ent)
        {
            DatosLaboratorio.InsertarLaboratorio(ent);
        }
        public static List<EntidadLaboratorio> GetLastIdRegLaboratorio(string dni_cliente, int anio, int mes, int dia)
        {
            return DatosLaboratorio.GetLastIdRegLaboratorio(dni_cliente, anio, mes, dia);
        }
    }
}
