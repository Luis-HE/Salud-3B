using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
  public  class LogicaReporteLibroMayor
    {
        public static List<EntidadReporteLibroMayor> ListReporteLibroMayorCabecera(string periodo_mes, int periodo_anio, string num_docCliente)
        {
            return DatosReporteLibroMayor.ListReporteLibroMayorCabecera(periodo_mes, periodo_anio, num_docCliente);
        }
        public static List<EntidadReporteLibroMayor> ListReporteLibroMayorDetalle(string periodo_mes, int periodo_anio, string cod_cuenta)
        {
            return DatosReporteLibroMayor.ListReporteLibroMayorDetalle(periodo_mes, periodo_anio, cod_cuenta);
        }
    }
}
