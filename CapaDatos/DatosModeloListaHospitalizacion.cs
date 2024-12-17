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
   public class DatosModeloListaHospitalizacion
    {
       public static List<EntidadModeloListaHospitalizacion> ListParaHospitalizacion( int dia, int mes, int anio)
        {
            List<EntidadModeloListaHospitalizacion> lst = new List<EntidadModeloListaHospitalizacion>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = "select TBL_CLIENTE_PERSONA.dni_cliente as dni, apellido_paterno +' '+apellido_materno as apellidos,nombres,tipo_admision,fecha_admision,nombre_familiar,tipo_paciente FROM TBL_CLIENTE_PERSONA INNER JOIN(TBL_ADMISION INNER JOIN TBL_DET_ADMISION ON TBL_ADMISION.numero_admision= TBL_DET_ADMISION.numero_admision) ON TBL_CLIENTE_PERSONA.dni_cliente= TBL_ADMISION.dni_cliente WHERE day(fecha_admision)='"+dia+"' AND MONTH(fecha_admision)='"+mes+"' AND YEAR(fecha_admision)='"+anio+"' AND codigo_item_catalogo='CUNIVSR00002' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadModeloListaHospitalizacion entListHospi = new EntidadModeloListaHospitalizacion()
                            {
                                dni_cliente = dr["dni"].ToString(),
                                apellidos = dr["apellidos"].ToString(),
                                nombres = dr["nombres"].ToString(),
                                tipo_admision = dr["tipo_admision"].ToString(),
                                fecha_admision = dr["fecha_admision"].ToString(),
                                nombre_familiar = dr["nombre_familiar"].ToString(),
                                tipo_paciente = dr["tipo_paciente"].ToString()
                             };
                            lst.Add(entListHospi);
                        }
                    }

                }
            }
            return lst;
        }
    }
}
