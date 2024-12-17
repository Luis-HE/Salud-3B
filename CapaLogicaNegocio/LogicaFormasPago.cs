using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaFormasPago
    {
        public static List<EntidadFormasPago> ListFormasPago(string fecha_pago, string tipo_doc, string serie, string num_doc_contable, int id_unidad_negocio)
        {
            return DatosFormasPago.ListFormasPago(fecha_pago, tipo_doc, serie, num_doc_contable, id_unidad_negocio);
        }
        public static void InsertFormasPago(EntidadFormasPago entForp)
        {
            DatosFormasPago.InsertFormasPago(entForp);
        }
        public static void UpdateFormasPago(EntidadFormasPago entForp)
        {
            DatosFormasPago.UpdateFormasPago(entForp);
        }
        public static void DeleteFormasPago(int id_reg_forma_pago)
        {
            DatosFormasPago.DeleteFormasPago(id_reg_forma_pago);
        }
    }
}
