using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Entidad_HC_CE_OFTALMOLOGIA
    {
        public int id_oftalmologia { get; set; }
        public string numero_historia_clinica { get; set; } 
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public int numero_admision { get; set; }
        public string fecha_registro { get; set; }
        public string hora_registro { get; set; }
        public int edad { get; set; }
        public string motivo_consulta { get; set; }
        public string tiempo_enfermedad { get; set; }
        public string agudeza_vusal_lejos_vod { get; set; }
        public string agudeza_vusal_lejos_vos { get; set; }
        public string agudeza_vusal_cerca_vod { get; set; }
        public string agudeza_vusal_cerca_vos { get; set; }
        public string examen_externo_od { get; set; }
        public string examen_externo_os { get; set; }
        public string antecedentes { get; set; }
        public string medios_transparentes_oculares { get; set; }
        public string motilidad_ocular { get; set; }
        public string tonometria_ocular_bidigital { get; set; }
        public string tonometria_ocular_schoitz { get; set; }
        public string tonometria_ocular_goldman { get; set; }
        public string fondo_ojo_od { get; set; }
        public string fondo_ojo_oi { get; set; }
        public string cod_cie_diez { get; set; }
        public string indicaciones { get; set; }
        public string tratamiento { get; set; }
        public string dni_empleado { get; set; }
        public int codigo_persona_pago { get; set; }
    }
}
