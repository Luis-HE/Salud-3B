using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using CapaEntidad;

namespace CapaDatos
{
   public class Datos_TBL_HC_FM_FICHA_FAMILIAR
    {
        public static void CreateFICHA_FAMILIAR(Entidad_TBL_HC_FM_FICHA_FAMILIAR ent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "insert into TBL_HC_FM_FICHA_FAMILIAR(id_ficha_familiar,numero_historia_clinica,numero_doc_cliente,codigo_persona,numero_admision,fecha_registro,nombre_diresa,nombre_red,nombre_microred,nombre_entidad_salud,familia_cantidad_integrantes,familia_cantidad_ninos,familia_cantidad_adolecentes,familia_cantidad_adultos,familia_cantidad_mayores,localidad_departamento,localidad_provincia,localidad_distrito,localidad_sector,localidad_area_residencia,localidad_direccion,localidad_telefono,localidad_tiempo_demora_llegar,localidad_medio_transporte_uso,localidad_tiempo_vive_residencia,localidad_residencia_anterior,localidad_disponibilidad_visitas,localidad_correo_electronico ) values('" + ent.id_ficha_familiar + "','" + ent.numero_historia_clinica + "','" + ent.numero_doc_cliente + "','" + ent.codigo_persona + "','" + ent.numero_admision + "','" + ent.fecha_registro + "','" + ent.nombre_diresa + "','" + ent.nombre_red + "','" + ent.nombre_microred + "','" + ent.nombre_entidad_salud + "','" + ent.familia_cantidad_integrantes + "' ,'" + ent.familia_cantidad_ninos + "','" + ent.familia_cantidad_adolecentes + "','" + ent.familia_cantidad_adultos + "','" + ent.familia_cantidad_mayores + "' ,'" + ent.localidad_departamento + "','" + ent.localidad_provincia + "','" + ent.localidad_distrito + "','" + ent.localidad_sector + "','" + ent.localidad_area_residencia + "','" + ent.localidad_direccion + "','" + ent.localidad_telefono + "','" + ent.localidad_tiempo_demora_llegar + "','" + ent.localidad_medio_transporte_uso + "','" + ent.localidad_tiempo_vive_residencia + "','" + ent.localidad_residencia_anterior + "' ,'" + ent.localidad_disponibilidad_visitas + "' ,'" + ent.localidad_correo_electronico + "'  )";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static List<Entidad_TBL_HC_FM_FICHA_FAMILIAR> ListFICHA_FAMILIAR()
        {
            List<Entidad_TBL_HC_FM_FICHA_FAMILIAR> lst = new List<Entidad_TBL_HC_FM_FICHA_FAMILIAR>();

            return lst;
        }
        public static void UPdateFICHA_FAMILIAR(Entidad_TBL_HC_FM_FICHA_FAMILIAR ent)
        {

        }
        public static void DeteleFICHA_FAMILIAR(int id_registro_ficha_familiar)
        {

        }
    }
}
