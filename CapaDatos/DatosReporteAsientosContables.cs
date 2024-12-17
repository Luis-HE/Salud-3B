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
  public  class DatosReporteAsientosContables
    {
        public static List<EntidadReporteAsientosContables> ListReporteAsientosContables(string periodo_mes,int periodo_anio,string num_docCliente)
        {
            List<EntidadReporteAsientosContables> lst = new List<EntidadReporteAsientosContables>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select id_reg_asiento,CONVERT(varchar(10), fecha_operacion,103) as fecha,descripcion_operacion,tipo_doc_contable,numero_doc_contable,cod_cuenta,descripcion,debe,haber,redondeo,periodo_anio,periodo_mes,num_doc_cliente,nombre_cliente from TBL_PLAN_CONTABLE inner join TBL_ASIENTO_CONTABLE on TBL_PLAN_CONTABLE.id_regPlanContable = TBL_ASIENTO_CONTABLE.id_regPlanContable where periodo_mes='" + periodo_mes + "' and periodo_anio='" + periodo_anio+"'  and num_doc_cliente='"+num_docCliente+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadReporteAsientosContables entAsiento = new EntidadReporteAsientosContables()
                            {
                                id_regAsiento = Convert.ToInt32(dr["id_reg_asiento"]),
                                fecha_operacion = dr["fecha"].ToString(),
                                descrip_operacion = dr["descripcion_operacion"].ToString(),
                                tipo_doc_contable = dr["tipo_doc_contable"].ToString(),
                                num_doc_contable = dr["numero_doc_contable"].ToString(),
                                cod_cuenta_contable = dr["cod_cuenta"].ToString(),
                                descripcion_cuenta = dr["descripcion"].ToString(),
                                debe = dr["debe"].ToString(),
                                haber = dr["haber"].ToString(),
                                redondeo = Convert.ToDecimal(dr["redondeo"]),                            
                                periodo_anio = Convert.ToInt32(dr["periodo_anio"]),
                                periodo_mes = dr["periodo_mes"].ToString(),
                                num_doc_cliente = dr["num_doc_cliente"].ToString(),
                                nombre_cliente = dr["nombre_cliente"].ToString()                                
                            };
                            lst.Add(entAsiento);
                        }

                    }
                }
            }
            return lst;
        }
    }
}
