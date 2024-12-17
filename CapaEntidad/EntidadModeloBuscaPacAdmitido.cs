using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntidadModeloBuscaPacAdmitido
    {
        public string num_doc_cliente { get; set; }
        public string paciente { get; set; }
        public string fecha_nace { get; set; }
        public string grupo_sanguineo { get; set; }
        public string direccion { get; set; }
        public string cod_item_catalogo { get; set; }
        public string descripcion_item { get; set; }
        public decimal p_unitario { get; set; } 
        public decimal p_venta { get; set; }
        public int cantidad { get; set; }
        public int numero_admision { get; set; }
        public string observacion { get; set; }
        public string tipo_paciente { get; set; }
        public string tipo_admision { get; set; }
        public string nombre_especialidad { get; set; }
        public string fecha_admision { get; set; }
        public string num_hist_clinica { get; set; }
        public int id_grupo { get; set; }
        public int id_clase { get; set; }
        public string genero { get; set; }
        public string grupo_etnico { get; set; }
        public string ubigeo { get; set; }
        public int edad { get; set; }
        public int id_reg_acompanante { get; set; }
        public string nombre_acompanante { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string talla { get; set; }
        public string peso { get; set; }
        public string presion_sistolica { get; set; }
        public string presion_diastolica { get; set; }
        public string frecuencia_cardiaca { get; set; }
        public string temperatura { get; set; }
        public string indice_masa_cuerpo { get; set; }
        public string frecuencia_respiratoria { get; set; }
        public string sp_oxigeno { get; set; }
    }
}
