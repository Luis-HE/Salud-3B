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
   public class DatosReporteCierreCaja
    {
        public static List<EntidadReporteCierreCaja> ListReporteCierreCaja(string fecha_inicio, string fecha_fin)
        {
            List<EntidadReporteCierreCaja> lst = new List<EntidadReporteCierreCaja>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                string query = @"SELECT fecha_cobranza, tipo_documento +'-'+numero_documento as Documento ,TBL.NumDoc,TBL.NomCliente, total FROM 
                                (SELECT TBL_PERSONA.codigo_persona AS CodCliente, numero_doc_cliente AS NumDoc, apellido_paterno + ' ' + apellido_materno + ' ' + nombres AS NomCliente  FROM TBL_PERSONA INNER JOIN TBL_CLIENTE_PERSONA ON TBL_PERSONA.codigo_persona = TBL_CLIENTE_PERSONA.codigo_persona
                                union all
                                SELECT TBL_PERSONA.codigo_persona AS CodCliente, ruc_cliente AS NumDoc, razon_social AS NomCliente                                                FROM TBL_PERSONA INNER JOIN TBL_CLIENTE_EMPRESA ON TBL_PERSONA.codigo_persona = TBL_CLIENTE_EMPRESA.codigo_persona) AS TBL
                                INNER JOIN TBL_DOCUMENTO_CONTABLE ON TBL.NumDoc = TBL_DOCUMENTO_CONTABLE.numero_documento_cliente
                                WHERE fecha_cobranza>= '"+fecha_inicio+"' and fecha_cobranza<= '"+fecha_fin+"' ";
                                                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadReporteCierreCaja entRepCaja = new EntidadReporteCierreCaja()
                            {
                                fecha_pago = dr["fecha_cobranza"].ToString(),
                                numero_documento = dr["Documento"].ToString(),
                                Num_doc_cliente = dr["NumDoc"].ToString(),
                                Nombre_cliente = dr["NomCliente"].ToString(),
                                monto_pago = Convert.ToDecimal(dr["total"])                                
                               
                            };
                            lst.Add(entRepCaja);
                        }
                    }

                }
            }
            return lst;
        }
    }
}
