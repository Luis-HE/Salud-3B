using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

using CapaEntidad;

namespace CapaDatos
{
  public  class Datos_HC_CE_OFTALMOLOGIA
    {
        public static void InserOftalmologia(Entidad_HC_CE_OFTALMOLOGIA ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_HC_CE_OFTALMOLOGIA(id_oftalmologia,numero_historia_clinica,numero_doc_cliente,codigo_persona,numero_admision,fecha_registro,hora_registro,edad,motivo_consulta,tiempo_enfermedad,agudeza_vusal_lejos_vod,agudeza_vusal_lejos_vos,agudeza_vusal_cerca_vod,agudeza_vusal_cerca_vos,examen_externo_od,examen_externo_os,antecedentes,medios_transparentes_oculares,motilidad_ocular,tonometria_ocular_bidigital,tonometria_ocular_schoitz,tonometria_ocular_goldman,fondo_ojo_od,fondo_ojo_oi,cod_cie_diez,indicaciones,tratamiento,dni_empleado, codigo_persona_pago ) values('" + ent.id_oftalmologia + "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.numero_admision + "','" + ent.fecha_registro + "','" + ent.hora_registro + "','" + ent.edad + "','" + ent.motivo_consulta + "','" + ent.tiempo_enfermedad + "','" + ent.agudeza_vusal_lejos_vod + "','" + ent.agudeza_vusal_lejos_vos + "','" + ent.agudeza_vusal_cerca_vod + "' ,'" + ent.agudeza_vusal_cerca_vos + "' ,'" + ent.examen_externo_od + "','" + ent.examen_externo_os + "','" + ent.antecedentes + "','" + ent.medios_transparentes_oculares + "','" + ent.motilidad_ocular + "','" + ent.tonometria_ocular_bidigital + "','" + ent.tonometria_ocular_schoitz + "' ,'" + ent.tonometria_ocular_goldman + "','" + ent.fondo_ojo_od + "','" + ent.fondo_ojo_oi + "','" + ent.cod_cie_diez + "','" + ent.indicaciones + "','" + ent.tratamiento + "' , '" + ent.dni_empleado + "' , '" + ent.codigo_persona_pago + "'   )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
