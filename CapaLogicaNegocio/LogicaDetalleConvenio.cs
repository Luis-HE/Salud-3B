using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;
namespace CapaLogicaNegocio
{
   public class LogicaDetalleConvenio
    {
        public static List<EntidadDetalleConvenio> ListDetalleConvenio()
        {
            return DatosDetalleConvenio.ListDetalleConvenio();
        }
        public static void InsertDetalleConvenio(EntidadDetalleConvenio ent)
        {
            DatosDetalleConvenio.InsertDetalleConvenio(ent);
        }
        public static void UpdateDetalleConvenio(EntidadDetalleConvenio ent)
        {
            DatosDetalleConvenio.UpdateDetalleConvenio(ent);
        }
        public static void UpdateDetalleConvenio(decimal precio, string cod_item_catalogo, int id_cia_seguro)
        {
            DatosDetalleConvenio.UpdateDetalleConvenio(precio, cod_item_catalogo, id_cia_seguro);
        }
        public static void DeleteDetalleConvenio(EntidadDetalleConvenio ent)
        {
            DatosDetalleConvenio.DeleteDetalleConvenio(ent);
        }
    }
}
