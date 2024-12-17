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
   public class DatosModeloBuscaPacCitado
    {
        public static List<EntidadModeloBuscaPacCitado> ListarPaccitado(string dni_cliente,string fecha,string hora)
        {
            List<EntidadModeloBuscaPacCitado> lst = new List<EntidadModeloBuscaPacCitado>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = @"SELECT TBL_CITA.id_cita, TBL_CLIENTE_PERSONA.numero_doc_cliente,apellido_paterno+' '+apellido_materno+' '+nombres AS paciente,tipo_paciente,nombre_cia_seguro,descripcion_item,observacion,codigo_item_catalogo,TBL_PROVEEDOR_SEGURO.id_cia_seguro,precio_citado,id_grupo,id_clase FROM TBL_PROVEEDOR_SEGURO INNER JOIN(TBL_CLIENTE_PERSONA INNER JOIN(TBL_CITA INNER JOIN TBL_CITA_DETALLE ON TBL_CITA.id_cita = TBL_CITA_DETALLE.id_cita) ON TBL_CLIENTE_PERSONA.numero_doc_cliente = TBL_CITA.numero_doc_cliente) ON TBL_PROVEEDOR_SEGURO.id_cia_seguro = TBL_CITA.id_cia_seguro
                                WHERE TBL_CLIENTE_PERSONA.numero_doc_cliente = '" + dni_cliente + "' AND fecha_cita = '"+ fecha + "' AND hora = '"+ hora + "' ";
                 con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadModeloBuscaPacCitado entBuscCitado = new EntidadModeloBuscaPacCitado()
                            {
                                numero_cita = Convert.ToInt32(dr["id_cita"]),
                                dni_cliente = dr["numero_doc_cliente"].ToString(),
                                nombre_cliente = dr["paciente"].ToString(),
                                tipo_paciente =  dr["tipo_paciente"].ToString(),
                                plan_asegurador = dr["nombre_cia_seguro"].ToString(),
                                descripcion_item =  dr["descripcion_item"].ToString(),
                                observacion = dr["observacion"].ToString(),
                                cod_item_catalogo = dr["codigo_item_catalogo"].ToString(),
                                cod_cia_seguro = Convert.ToInt32(dr["id_cia_seguro"]),
                                precio_citado = Convert.ToDecimal(dr["precio_citado"]),
                                id_grupo = Convert.ToInt32(dr["id_grupo"]),
                                id_clase = Convert.ToInt32(dr["id_clase"])

                            };
                            lst.Add(entBuscCitado);
                        }
                    }

                }
            }
            return lst;
        }
    }
}
