using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogicaNegocio
{
   public  class LogicaAnulaDocumentos
    {
        public static void AnularDocumentos(int numero_documento, string tipo_docuento, string serie, int id_unidad_negocio)
        {
             DatosAnulaDocumentos.AnularDocumentos( numero_documento,  tipo_docuento,  serie,  id_unidad_negocio);
        }
    }
}
