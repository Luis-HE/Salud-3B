using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntidadHospitalizacion
    {
        public int id_registro_hospitalizacion { get; set; }
        public string numero_historia_clinica { get; set; }
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public string tipo_movimiento { get; set; }
        public string fecha_ingreso_egreso { get; set; } 
        public string hora_ingreso_egreso { get; set; }
        public string origen_ingreso_egreso { get; set; }
        public int id_cama { get; set; }
        public int id_piso { get; set; }
        public int edad { get; set; }
        public bool recien_nacido { get; set; }
        public string medico_autoriza_ingreso_egreso { get; set; }
        public string servicio_ingresa_egresa { get; set; }
        public string cod_cie_diez { get; set; }
        public int id_reg_acompanante { get; set; }
        public string destino_egreso { get; set; }
        public string tipo_alta { get; set; }
        public string condicion_alta { get; set; }
        public int numero_admision { get; set; }
 
    }
}
