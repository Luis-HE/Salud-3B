using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaKardex
    {
        public static List<EntidadKardex> ListKardex()
        {
            return DatosKardex.ListKardex();
        }
        public static void InsertKardex(EntidadKardex entKdx)
        {
            DatosKardex.InsertKardex(entKdx);
        }
        public static void UpdateKardex(int cantidad_mueve, decimal precio_actual , string codigo_item_catalog, int codigo_almacen)
        {
            DatosKardex.UpdateKardex(cantidad_mueve, precio_actual, codigo_item_catalog, codigo_almacen);
        }
        public static void UpdateKardex(decimal precio, string codigo_item_catalogo)
        {
            DatosKardex.UpdateKardex(precio, codigo_item_catalogo);
        }
        public static void DeleteKardex(EntidadKardex entKdx)
        {
            DatosKardex.DeleteKardex(entKdx);
        }
        public static void ActualizaStockMinimo(int sockMin, decimal precio_actual, string coditem_catalogo)
        {
            DatosKardex.ActualizaStockMinimo(sockMin, precio_actual, coditem_catalogo);
        }
         
    }
}
