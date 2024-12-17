using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
  public  class LogicaConsultorioRecetaMedicaDetalle
    {
        public static void InsertarRecetaMedicaDetalle(EntidadConsultorioRecetaMedicaDetalle entR)
        {
            DatosConsultorioRecetaMedicaDetalle.InsertarRecetaMedicaDetalle(entR);
        }
        public static void ActualizarEstadoItemReceta(string codigo_item_catalogo, int numero_admision)
        {
            DatosConsultorioRecetaMedicaDetalle.ActualizarEstadoItemReceta(codigo_item_catalogo, numero_admision);
        }
    }
}
