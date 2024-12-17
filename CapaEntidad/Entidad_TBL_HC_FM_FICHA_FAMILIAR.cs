using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Entidad_TBL_HC_FM_FICHA_FAMILIAR
    {
        public int id_ficha_familiar { get; set; }
        public string numero_historia_clinica { get; set; }
        public string numero_doc_cliente { get; set; }
        public int codigo_persona { get; set; }
        public int numero_admision { get; set; }
        public string fecha_registro { get; set; }
        public string nombre_diresa { get; set; }
        public string nombre_red { get; set; }
        public string nombre_microred { get; set; }
        public string nombre_entidad_salud { get; set; }
        public int familia_cantidad_integrantes { get; set; }
        public int familia_cantidad_ninos { get; set; }
        public int familia_cantidad_adolecentes { get; set; }
        public int familia_cantidad_adultos { get; set; }
        public int familia_cantidad_mayores { get; set; }
        public string localidad_departamento { get; set; }
        public string localidad_provincia { get; set; }
        public string localidad_distrito { get; set; }
        public string localidad_sector { get; set; }
        public string localidad_area_residencia { get; set; }
        public string localidad_direccion { get; set; }
        public string localidad_telefono { get; set; }
        public string localidad_tiempo_demora_llegar { get; set; }
        public string localidad_medio_transporte_uso { get; set; }
        public string localidad_tiempo_vive_residencia { get; set; }
        public string localidad_residencia_anterior { get; set; }
        public string localidad_disponibilidad_visitas { get; set; }
        public string localidad_correo_electronico { get; set; }
    }
}
