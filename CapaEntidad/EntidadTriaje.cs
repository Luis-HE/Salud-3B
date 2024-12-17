using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntidadTriaje
    {
        public int id_registro_triaje { get; set; }
        public int numero_admision { get; set; }
        public string num_hist_clinica { get; set; }
        public string num_doc_cliente { get; set; }
        public int cod_persona { get; set; }
        public string talla { get; set; }
        public string edad { get; set; }
        public string peso { get; set; }
        public string presion_arterial_sistolica { get; set; }
        public string presion_arterial_diastolica { get; set; }
        public string temperatura { get; set; }
        public string prioridad { get; set; }
        public string frecuencia_cardiaca { get; set; }
        public string indice_masa_corporal { get; set; }
        public string frecuencia_respiratoria { get; set; }
        public string sp_oxigeno { get; set; }

        public string gineco_problema_principal { get; set; }
        public string gineco_tiempo_embarazo { get; set; }
        public string gineco_diabetes_mellitus { get; set; }
        public string gineco_hipertension_arterial { get; set; }
        public string gineco_cardiopatia { get; set; }
        public string gineco_enf_tiroidea { get; set; }
        public string gineco_enf_renal { get; set; }
        public string gineco_otras_patologias { get; set; }
        public string gineco_amenaza_aborto { get; set; }
        public string gineco_amenaza_parto { get; set; }
        public string gineco_embarazo_termino { get; set; }
        public string gineco_enf_hipertensiva { get; set; }
        public string gineco_hemorragia { get; set; }
        public string gineco_sepsis { get; set; }
        public string gineco_otros_problemas { get; set; }
        public string gineco_sintomatologia { get; set; }
        public string gineco_indice_choque { get; set; }
        public string gineco_diagnostico_probable { get; set; }
        public string gineco_plan_terapeutico { get; set; }

        public string num_doc_pago { get; set; }
        public string serie_doc_pago { get; set; }
        public string tipo_doc_pago { get; set; }
        public string fecha_atencion { get; set; }
        public string hora_atencion { get; set; }

        public string dni_empleado { get; set; }
        public int codigo_persona_pago { get; set; }


        //====================cola triaje
        public string numdoc { get; set; }
        public string tipo_admision { get; set; }
        public string apelPater { get; set; }
        public string apelMater { get; set; }
        public string fecha_nace { get; set; }
        public decimal mont_adelanto { get; set; }
        public decimal monto_total { get; set; }
         


    }
}
