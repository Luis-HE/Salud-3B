using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using CapaEntidad;

namespace CapaDatos
{
   public class DatosConceptos
    {
        public static void CreateConcepto(EntidadConceptos entConcepto)
        {

        }
        public static List<EntidadConceptos> ReadConcepto()
        {
            List<EntidadConceptos> lst = new List<EntidadConceptos>();
            return lst;
        }
        public static void UpdateConcepto(EntidadConceptos entConcepto)
        {

        }
        public static void DeleteConcepto(EntidadConceptos entConcepto)
        {

        }
    }
}
