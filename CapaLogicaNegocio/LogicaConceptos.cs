using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaLogicaNegocio
{
  public  class LogicaConceptos
    {
        public static void CreateConcepto(EntidadConceptos entConcepto)
        {
            DatosConceptos.CreateConcepto(entConcepto);
        }
        public static List<EntidadConceptos> ReadConcepto()
        {
            return DatosConceptos.ReadConcepto();
        }
        public static void UpdateConcepto(EntidadConceptos entConcepto)
        {
            DatosConceptos.UpdateConcepto(entConcepto);
        }
        public static void DeleteConcepto(EntidadConceptos entConcepto)
        {
            DatosConceptos.DeleteConcepto(entConcepto);
        }
    }
}
