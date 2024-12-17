using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaConvenio
    {
        public static List<EntidadConvenio> ListConvenios()
        {
            return DatosConvenio.ListConvenios(); 
        }
        public static void InsertConvenio(EntidadConvenio entcon)
        {
            DatosConvenio.InsertConvenio(entcon);
        }
        public static void UpdateConvenio(EntidadConvenio entcon)
        {
            DatosConvenio.UpdateConvenio(entcon);
        }
        public static void DeleteConvenio(EntidadConvenio entcon)
        {
            DatosConvenio.DeleteConvenio(entcon);
        }
    }
}
