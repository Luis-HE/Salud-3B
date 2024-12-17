using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadAcompanante
    {
        public int id_reg_acompnante { get; set; }
        public string dni_ruc_acompanante { get; set; }
        public int codigo_persona { get; set; }
        public string nombre_acompanante { get; set; }
        public string apellido_acompanante { get; set; }
        public string parentesco { get; set; }
        public string nombre_contacto { get; set; }
        public string ocupacion { get; set; }
        public string telefono { get; set; }
        public string grupo_etnico { get; set; }
        public string idioma_principal { get; set; }
        public string religion { get; set; }
        public string estado_civil { get; set; }
        public string genero { get; set; }
        public int edad { get; set; }
        public string grado_instruccion { get; set; }
        public string condicion_ocupacion { get; set; }
        public string seguro_salud { get; set; }
        
    }
}
