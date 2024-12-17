using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
  public  class LogicaMovimientoCatalogo
    {
        public static List<EntidadMovimientoCatalogo> ListMovimientosProductos()
        {
            return DatosMovimientoCatalogo.ListMovimientosProductos();
        }
        public static void InsertMovimientoCatalogo(EntidadMovimientoCatalogo entMovCat)
        {
            DatosMovimientoCatalogo.InsertMovimientoCatalogo(entMovCat);
        }
         
    }
}
