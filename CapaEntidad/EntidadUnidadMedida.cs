using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadUnidadMedida
    {
        public int cod_unidad_medida { get; set; }
        public string siglas { get; set; }
        public string nombre_medida { get; set; }
        public string cod_unidad_sunat { get; set; }
    }
}
