using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
   public class LogicaDocumentoContable
    {
        public static void CreateDocumentoContableAdmin(EntidadDocumentoContable entDocContable)
        {
            DatosDocumentoContable.CreateDocumentoContableAdmin(entDocContable);
        }
        public static void CreateDocumentoContable(EntidadDocumentoContable entDocContable)
        {
            DatosDocumentoContable.CreateDocumentoContable(entDocContable);
        }
        public static List<EntidadDocumentoContable> ReadDocumentoContable()
        {
            return DatosDocumentoContable.ReadDocumentoContable();
        }
        public static void UpdateDocumentoContable(EntidadDocumentoContable entDocContable)
        {
            DatosDocumentoContable.UpdateDocumentoContable(entDocContable);
        }
        public static void DeleteDocumentoContable(EntidadDocumentoContable entDocContable)
        {
            DatosDocumentoContable.DeleteDocumentoContable(entDocContable);
        }
    }
}
