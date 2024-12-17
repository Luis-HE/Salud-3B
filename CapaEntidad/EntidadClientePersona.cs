using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class EntidadClientePersona
    {
        public string num_doc_cliente { get; set; }
        public int cod_persona { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string nombres { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }  
        public string email { get; set; }
        public string genero { get; set; }
        public string dni_vendedor { get; set; }
        public string direccion { get; set; }
        public string grupo_sanguineo { get; set; }
        public string fecha_nace { get; set; }
        public int cod_nacionalidad { get; set; }
        public string id_ubigeo { get; set; }
        public string estado_civil { get; set; }
        public string nombre_padre { get; set; }
        public string nombre_madre { get; set; }
        public string religion { get; set; }
        public string ocupacion { get; set; }
        public string grupo_etnico { get; set; }
    }
}
