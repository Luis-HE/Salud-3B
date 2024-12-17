using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
   public class LogicaCorrelativoDocumentos
    {
        public static List<EntidadCorrelativoDocumentos> ListCorrelativoDocumentosSeries(int id_unidad_negocio)
        {
            return DatosCorrelativoDocumentos.ListCorrelativoDocumentosSeries(id_unidad_negocio);
        }
        public static List<EntidadCorrelativoDocumentos> ListCorrelativoDocumento(string tipo_doc, string serie, int id_unidad_negocio)
        {
            return DatosCorrelativoDocumentos.ListCorrelativoDocumento(tipo_doc, serie, id_unidad_negocio);
        }
        public static void UpdateCorrelativoDocumento(string tipo_doc, string serie, int id_unidad_negocio)
        {
            DatosCorrelativoDocumentos.UpdateCorrelativoDocumento(tipo_doc, serie, id_unidad_negocio);
        }
    }
}
