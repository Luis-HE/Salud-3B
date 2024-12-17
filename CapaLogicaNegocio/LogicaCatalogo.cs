using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
  public  class LogicaCatalogo
    {
        public static List<EntidadCatalogo> ListItemsCatalogo(int id_ciaSeg, string descrip_item)
        {
            return DatosCatalogo.ListItemsCatalogo(id_ciaSeg, descrip_item);
        }
        public static List<EntidadCatalogo> ListItemsCatalogo(int opcion,string tipo_item, string descrip_item)
        {
            return DatosCatalogo.ListItemsCatalogo(opcion,tipo_item, descrip_item);
        }
         public static List<EntidadCatalogo> CountItemsCatalogo(string tipo_item_catalogo)
        {
            return DatosCatalogo.CountItemsCatalogo(tipo_item_catalogo);
        }
        public static void InsertCatalogo(EntidadCatalogo entCatal)
        {
            DatosCatalogo.InsertCatalogo(entCatal);
        }
        public static void ModificarItemCatalogo(EntidadCatalogo entCatal)
        {
            DatosCatalogo.ModificarItemCatalogo(entCatal);
        }
        public static void ModificarPrecioCatalogo(decimal precio, string cod_item_catalogo)
        {
            DatosCatalogo.ModificarPrecioCatalogo(precio, cod_item_catalogo);
        }
        public static void EliminarItemCatalogo(string cod_item_catalogo)
        {
            DatosCatalogo.EliminarItemCatalogo(cod_item_catalogo);
        }
    }
}
