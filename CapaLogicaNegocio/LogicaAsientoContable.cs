using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaAsientoContable
    {
        public static List<EntidadAsientoContable> ListAsientosContables(int periodo_anio, string num_doc_cliente)
        {
            return DatosAsientoContable.ListAsientosContables(periodo_anio, num_doc_cliente);
        }
        public static void InsertAsientoContable(string tipo_doc, string numero_doc)
        {
            DatosAsientoContable.InsertAsientoContable(tipo_doc, numero_doc);
        }
    }
}
