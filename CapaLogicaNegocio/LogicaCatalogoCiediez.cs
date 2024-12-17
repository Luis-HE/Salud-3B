using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaCatalogoCiediez
    {
        public static List<EntidadCatalogoCiediez> ListCatalogoCiediez()
        {
            return DatosCatalogoCiediez.ListCatalogoCiediez();
        }
        public static List<EntidadCatalogoCiediez> ListCatalogoCiediez(string nombre)
        {
           return DatosCatalogoCiediez.ListCatalogoCiediez(nombre);
        }
    }
}
